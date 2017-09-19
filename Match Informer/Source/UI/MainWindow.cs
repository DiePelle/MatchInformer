using MatchInformer.Source.WindowsAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using FTimer = System.Windows.Forms.Timer;

namespace MatchInformer.Source.UI
{
    public partial class MainWindow : MetroFramework.Forms.MetroForm
    {
        #region Vars
        Process process = null; //Process
        Memory mem      = null; //Memory
        Offsets offsets = null; //Offsets
        FTimer timer    = null; //Timer for reveal ranks

        //For the filterbutton ;_;
        public enum FilterTypes { ALL, CT, T };
        string[] filter = new string[] { "ALL", "CT", "T" };
        int currentlySelected = 0;
        #endregion       

        /// <summary>
        /// Constructor.. Meh :/
        /// </summary>
        public MainWindow(){
            InitializeComponent();
        }

        #region Initialization Stuff        
        /// <summary>
        /// Beauty Stuff... Not really usefull and makes it 10000000x longer to load.. For the memes I guess?
        /// Don't know if that Invoke on the window is efficient, but that is anyways just a troll, lol....
        /// </summary>
        private void Start() {
            Invoke(new Action(() => {
                progressBar.Value = 0;//0
                progressOutput.Text = "Initializing";
            }));
            
            //Write to screen that it is being initialized
            Debug.WriteLine("Beginning initialization");

            Thread.Sleep(1000);
            Invoke(new Action(() => {
                progressBar.Value = 5; //5
                progressOutput.Text = "Fetching CS:GO Process";
            }));

            //Fetch the CS:GO Process/Wait for it
            if (!WaitAndFetchProcess()) { abort("Can not fetch the CS:GO process"); return; } // 30

            Thread.Sleep(3000);
            Invoke(new Action(() => {
                progressBar.Value = 30; //30
                progressOutput.Text = "Validating";
            }));
            
            //Create a new memory control instance
            if (mem.client == null || mem.engine == null) { abort("Memory Controller was not created successfully. Abort."); return; } //55

            Thread.Sleep(1000);
            Invoke(new Action(() => {
                progressBar.Value = 55; //55
                progressOutput.Text = "Scanning for offsets and addresses";
            }));
            
            //Fetch all addresses
            if (!(offsets = new Offsets()).PatternScan()) { abort("Can not fetch the offsets. Abort."); return; } // 80
            offsets.RenewOffsets();

            Thread.Sleep(2000);
            Invoke(new Action(() => {
                progressBar.Value = 90; //90
                progressOutput.Text = "Validating";
            }));

            //Setup the timer
            timer = new FTimer {
                Interval = 10
            };
            timer.Tick += new EventHandler(RunThread);
            Thread.Sleep(1000);
            Invoke(new Action(() => {
                progressBar.Value = 100; //100
                progressOutput.Text = "Preparing Rank Reveal.";
            }));

            //Write to screen that it succeded(, else close application)
            Debug.WriteLine("Suceeded.");

            Thread.Sleep(2500);
            Invoke(new Action(() => {
                progressBar.Value = 100; //100
                progressOutput.Text = "Successfully loaded";
            }));

            Thread.Sleep(1000);
            Invoke(new Action(() => {
                LoadingScreen.Visible = false;
            }));
        }

        /// <summary>
        /// Abort function if something goes wrong to display information on screen and have a organized shutdown..
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        private void abort(string message) {
            Invoke(new Action(() => {
                progressOutput.Text = message;
            }));
            Thread.Sleep(5000);
            Environment.Exit(0);
        }

        /// <summary>
        /// Waits for the Memory Control to be created
        /// </summary>
        /// <returns>
        /// true:   memory instance was successfully created
        /// false:  can not be reached for now
        /// </returns>
        private bool WaitAndFetchProcess() {
            while ((mem = Memory.Instance) == null)
                Thread.Sleep(1000);

            //Found one, return it.
            return true;
        }
        #endregion

        #region Misc Methods
        /// <summary>
        /// Is run every 10ms when activated
        /// </summary>
        /// <param name="sender">~Object</param>
        /// <param name="e">~EventArgs</param>
        public void RunThread(object sender, EventArgs e) {
            if (Win32.GetAsyncKeyState((int)(Keys.Tab) & 0x8000) != 0) {
                if (offsets.IsIngame())
                    unsafe_RevealAll();
            }
        }

        /// <summary>
        /// Calls the Reveal All function in csgo
        /// </summary>
        /// <returns>If it succeeded or not</returns>
        private unsafe bool unsafe_RevealAll() {
            try {
                //If address for the reveal function was not found return
                if (offsets.GetReavealRank() == IntPtr.Zero)  //REVEAL ALL FUNC -> client.dll, "55 8B EC 8B 0D ? ? ? ? 68"
                    return false;

                IntPtr processHandle = Win32.OpenProcess((int)Win32.PROCESS_VM.ALL, false, process.Id); //Get a handle for writing, probably an other handle is more adequate
                float[] param = new float[] { 0, 0, 0 }; //Empty float* as parameter
                byte[] asm_stub = { //<- Revealrank - https://www.unknowncheats.me/forum/1542524-post20.html
                    0x68, 0x00, 0x00, 0x00, 0x00,   // push float* (Index 1)
                    0x55, 0x89, 0xE5,               // cdecl call frame
                    0xB8, 0x00, 0x00, 0x00, 0x00,   // mov    eax,0x00000000 (Index 9)
                    0xFF, 0xD0,                     // call   eax
                    0x83, 0xC4, 0x4,                // clear stack
                    0x5D,                           // reset call frame
                    0xC3                            // return
                };

                //Allocate space in the target process (12 bytes)
                IntPtr paramSpace = Win32.VirtualAllocEx(processHandle, IntPtr.Zero, 0x0C, 0x1000, 0x40);
                if (paramSpace == IntPtr.Zero) //Checkz
                    return false;

                //Write the float array to the address
                fixed (float* pParam = param) {
                    if (!Win32.WriteProcessMemory(processHandle, paramSpace, (IntPtr)pParam, param.Length, IntPtr.Zero))
                        return false;
                }
                byte[] bytes = BitConverter.GetBytes(paramSpace.ToInt32()); //well.. Convert...
                bytes.CopyTo(asm_stub, 1); //Update the stub with the float array address in the targets address space
                bytes = BitConverter.GetBytes(offsets.GetReavealRank().ToInt32()); //well.. Convert...
                bytes.CopyTo(asm_stub, 9); //Update the stub with the revealAll address in the targets address space

                //Allocate space in the target process (20 bytes)
                IntPtr asmSpace = Win32.VirtualAllocEx(processHandle, IntPtr.Zero, 0x14, 0x1000, 0x40);
                if (asmSpace == IntPtr.Zero) //Checkz
                    return false;

                //Write the shellcode to the address
                fixed (byte* pShellcode = asm_stub) {
                    if (!Win32.WriteProcessMemory(processHandle, asmSpace, (IntPtr)pShellcode, asm_stub.Length, IntPtr.Zero))
                        return false;
                }

                IntPtr hTr = IntPtr.Zero;
                if (Win32.RtlCreateUserThread(processHandle, IntPtr.Zero, false, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, asmSpace, IntPtr.Zero, ref hTr, IntPtr.Zero) != 0) { //If the creation was no success
                                                                                                                                                                             //Release the allocated memory, of course!
                    Win32.VirtualFreeEx(processHandle, asmSpace, 0x14, 0x8000/*AllocationType.Release*/);
                    Win32.VirtualFreeEx(processHandle, paramSpace, 0x0C, 0x8000/*AllocationType.Release*/);
                    Win32.CloseHandle(processHandle);
                    return false;
                }

                Win32.WaitForSingleObject(hTr, 0xFFFFFFFF); //Wait for it to complete
                Win32.CloseHandle(hTr); //Close the handle of course

                //Free the space in the target process!
                Win32.VirtualFreeEx(processHandle, asmSpace, 0x14, 0x8000/*AllocationType.Release*/);
                Win32.VirtualFreeEx(processHandle, paramSpace, 0x0C, 0x8000/*AllocationType.Release*/);
                Win32.CloseHandle(processHandle);
                return true;
            } catch (Exception) {
                return false;
            }
        }

        /// <summary>
        /// Finds the matchmaking information
        /// </summary>
        /// <param name="ignoreBots">Should bots be ignored?</param>
        /// <param name="steamInfo">Should steam info be shown?</param>
        /// <returns>Formatted string with information</returns>
        private string getMatchmakingInfoAsString(bool ignoreBots, bool steamInfo, FilterTypes filter) {
            offsets.RenewOffsets();
            if (!offsets.IsIngame()) return "Not ingame";

            List<Offsets.Player> playerList = offsets.GetPlayers(ignoreBots, filter);
            if (playerList == null) return "No valid player was found";

            string temp = "";
            for (int i = 0; i < playerList.Count; i++) {
                if (playerList[i].name.Length <= 0)
                    continue;

                temp += "[" + (i+1) + "]        " + (i+1<10 ? " " : "") + playerList[i].name + " \n";
                temp += "Rank:       " + Offsets.RANKS[playerList[i].rank] + "\n";
                temp += "Wins:       " + playerList[i].winCount + "\n";
                if (steamInfo) {
                    temp += "SteamID:    " + playerList[i].steamID + "\n";
                    temp += "SteamID3:   " + playerList[i].steamID3 + "\n";
                    temp += "SteamID64:  " + playerList[i].steamID64 + "\n";
                    temp += "Profile:    " + playerList[i].profileLink + "\n";
                }
                if(i+1 < playerList.Count)
                    temp += "\n\n";
            }
            return temp.Replace("\n", Environment.NewLine);
        }
        #endregion

        #region Form Related
        /// <summary>
        /// Creates the initializatiion thread
        /// </summary>
        /// <param name="sender">~Object</param>
        /// <param name="e">~MouseEventArgs</param>
        private void MainWindow_Shown(object sender, EventArgs e) {
            new Thread(Start).Start();
        }

        /// <summary>
        /// Called when the form is closed and closes the application
        /// </summary>
        /// <param name="sender">~Object</param>
        /// <param name="e">~MouseEventArgs</param>
        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Invokes a refresh of the frame, since we are changing the text to the new one recieved from getMatchmakingInfoAsString
        /// </summary>
        /// <param name="sender">~Object</param>
        /// <param name="e">~MouseEventArgs</param>
        private void buttonFetch_MouseClick(object sender, MouseEventArgs e) {
            //Button
            Invoke(new Action(() => {
                generalOutput.Text = getMatchmakingInfoAsString(toggleIgnoreBots.Checked, toggleIncludeSteamInfo.Checked, (FilterTypes)currentlySelected);
            }));
        }

        /// <summary>
        /// Copies the content of the textbox to the clipboard
        /// </summary>
        /// <param name="sender">~Object</param>
        /// <param name="e">~MouseEventArgs</param>
        private void buttonCopy_MouseClick(object sender, MouseEventArgs e) {
            //Button
            Clipboard.SetText(generalOutput.Text);
        }

        /// <summary>
        /// If the toggle checked was changed this method is called and controls the timer therefore
        /// </summary>
        /// <param name="sender">~Object</param>
        /// <param name="e">~EventArgs</param>
        private void toggleRevealRanks_CheckedChanged(object sender, EventArgs e) {
            if (toggleRevealRanks.Checked)
                timer.Start();
            else
                timer.Stop();
        }

        /// <summary>
        /// Increases the current filter num
        /// </summary>
        /// <param name="sender">~Object</param>
        /// <param name="e">~MouseEventArgs</param>
        private void playerFilterBackward_MouseClick(object sender, MouseEventArgs e) {
            playerFilter.Text = filter[(currentlySelected-1 >= 0) ? (currentlySelected = currentlySelected -1) : (currentlySelected = filter.Length-1)];
        }

        /// <summary>
        /// Decreases the current filter num
        /// </summary>
        /// <param name="sender">~Object</param>
        /// <param name="e">~MouseEventArgs</param>
        private void playerFilterForward_MouseClick(object sender, MouseEventArgs e) {
            playerFilter.Text = filter[(currentlySelected+1 <= filter.Length-1) ? (currentlySelected = currentlySelected + 1) : (currentlySelected = 0)];
        }
        #endregion

    }
}
