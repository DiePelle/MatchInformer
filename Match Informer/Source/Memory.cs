using System;
using MatchInformer.Source.WindowsAPI;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MatchInformer.Source
{
    public sealed class Memory
    {
        #region Instance stuff
        private static Memory instance = null; //new Memory();
        public static Memory Instance
        {
            get {
                try
                {
                    if (Process.GetProcessesByName("csgo").Length > 0)
                        return instance ?? new Memory();
                    else return null;
                }
                catch (Exception)
                { 
                    return (instance = null);
                }
            }
        }
        #endregion

        #region Vars
        private Process process;
        public ProcessModule client = null,
            engine = null;
        #endregion


        /// <summary>
        /// Creates a new instance of the memory control
        /// Saves the client and engine process module
        /// </summary>
        /// <param name="proc">Process to control</param>
        private Memory() {
            process = Process.GetProcessesByName("csgo")[0];
            if (process == null) throw new Exception("Process csgo was not found, so no new instance of the Memory class can be created.");

            foreach (ProcessModule m in process.Modules) {
                if (m.ModuleName == "client.dll")
                    client = m;
                else if (m.ModuleName == "engine.dll")
                    engine = m;
            }
            if (client == null || engine == null) throw new Exception("Process csgo was not found, so no new instance of the Memory class can be created.");
        }

        #region Reading / Writing
        /// <summary>
        /// Reads managed structures from the process at the given adress
        /// </summary>
        /// <typeparam name="T">Managed Datatype</typeparam>
        /// <param name="ptr">Adress in memory to read from</param>
        /// <returns>Structure or value that you wanted to read</returns>
        public T Read<T>(int ptr) {
            try {
                IntPtr processHandle = Win32.OpenProcess((int)Win32.PROCESS_VM.READ, false, process.Id);
                int size = Marshal.SizeOf(typeof(T));
                byte[] buffer = new byte[size];
                int read = 0;

                Win32.ReadProcessMemory(processHandle.ToInt32(), ptr, buffer, size, ref read);
                GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                T data = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));

                handle.Free();
                Win32.CloseHandle(processHandle);
                return data;
            } catch (Exception) {
                return default(T);
            }
        }

        public string Read(int ptr, int size) {
            try {
                IntPtr processHandle = Win32.OpenProcess((int)Win32.PROCESS_VM.READ, false, process.Id);
                byte[] buffer = new byte[size];
                int read = 0;
                Win32.ReadProcessMemory(processHandle.ToInt32(), ptr, buffer, size, ref read);
                Win32.CloseHandle(processHandle);
                return BitConverter.ToString(buffer);
            } catch (Exception) {
                return "";
            }
        }

        /// <summary>
        /// Writes managed structures to the process at the given adress
        /// </summary>
        /// <typeparam name="T">Managed Datatype</typeparam>
        /// <param name="ptr">Adress in memory to write to</param>
        /// <returns>Structure or value that you want to write</returns>
        public void Write<T>(int ptr, T data) {
            try {
                IntPtr processHandle = Win32.OpenProcess((int)Win32.PROCESS_VM.ALL, false, process.Id);

                int size = Marshal.SizeOf(typeof(T));
                byte[] buffer = new byte[size];
                GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                Marshal.StructureToPtr(data,
                    handle.AddrOfPinnedObject(),
                    false);
                handle.Free();

                int written = 0;
                Win32.WriteProcessMemory(processHandle.ToInt32(), ptr, buffer, buffer.Length, ref written);

                Win32.CloseHandle(processHandle);
            } catch (Exception) {
                return;
            }
        }
        #endregion

        #region Pattern Stuuff
        public static byte[] HexStringToBytes(string s) {
            const string HEX_CHARS = "0123456789ABCDEF";

            if (s.Length == 0)
                return new byte[0];

            if ((s.Length + 1) % 3 != 0)
                throw new FormatException();

            byte[] bytes = new byte[(s.Length + 1) / 3];

            int state = 0; // 0 = expect first digit, 1 = expect second digit, 2 = expect hyphen
            int currentByte = 0;
            int x;
            int value = 0;

            foreach (char c in s) {
                switch (state) {
                    case 0:
                        x = HEX_CHARS.IndexOf(Char.ToUpperInvariant(c));
                        if (x == -1)
                            throw new FormatException();
                        value = x << 4;
                        state = 1;
                        break;
                    case 1:
                        x = HEX_CHARS.IndexOf(Char.ToUpperInvariant(c));
                        if (x == -1)
                            throw new FormatException();
                        bytes[currentByte++] = (byte)(value + x);
                        state = 2;
                        break;
                    case 2:
                        if (c != '-')
                            throw new FormatException();
                        state = 0;
                        break;
                }
            }

            return bytes;
        }

        /// <summary>
        /// Find module, if no data about it exists serach for it..!
        /// Go through the Pattern and check for similarities
        /// Return Pattern if found, else return IntPtr.Zero
        /// </summary>
        /// <param name="module">Module to search in</param>
        /// <param name="pattern">Signature to be searched</param>
        /// <param name="extra">Extra to be added</param>
        /// <param name="offset">Offset to be added to the address</param>
        /// <param name="read">Shall the found address be read?</param>
        /// <param name="subtract">Shall the module base address be subtracted from the address?</param>
        /// <returns></returns>
        public IntPtr FindPattern(string module, string pattern, int extra, int offset, bool read, bool subtract) {
            //Filtering
            if (module.Length == 0 || pattern.Length == 0)
                return IntPtr.Zero;

            //General vars
            ProcessModule pm = null;
            int patternSize = 0;

            //How many bytes are in the sig
            for (int i = 0; i < pattern.Length; i++) {
                if (pattern[i] != ' ') {
                    if (pattern[i] != '?')
                        i++;
                    patternSize++;
                }

            }

            //Nothing found? return!
            if (patternSize == 0)
                return IntPtr.Zero;

            //Another vars
            byte[] bytePattern = new byte[patternSize];
            char[] sPattern = new char[patternSize];

            //Log all modules and initialize the initial one
            foreach (ProcessModule m in process.Modules)
                if (m.ModuleName == module)
                    pm = m;

            //If not a single one was found, return zero
            if (pm == null)
                return IntPtr.Zero;

            //Another vars + filling the buffer
            IntPtr procHandle = Win32.OpenProcess((int)Win32.PROCESS_VM.READ, false, process.Id);
            byte[] buffer = new byte[pm.ModuleMemorySize];
            int iRead = 0;
            Win32.ReadProcessMemory((int)procHandle, (int)pm.BaseAddress, buffer, pm.ModuleMemorySize, ref iRead);
            Win32.CloseHandle(procHandle);

            //Convert the pattern
            for (int i = 0, realPos = 0; i < pattern.Length; i++) {
                if (pattern[i] != ' ') {
                    if (pattern[i] != '?') {
                        sPattern[realPos] = 'x';
                        bytePattern[realPos] = HexStringToBytes(pattern.Substring(i, 2))[0]; //Convert.ToByte(pattern.Substring(i, 2)); <- apparently does not work :/
                        i++;
                    } else {
                        sPattern[realPos] = '?';
                        bytePattern[realPos] = 0x00;
                    }
                    realPos++;
                }
            }

            for (int x = 0; x < buffer.Length; x++) {
                if (check(x, bytePattern, sPattern, buffer)) {
                    int addressFound = (int)(pm.BaseAddress + (x + extra));
                    if (read) {
                        if (subtract)
                            return new IntPtr((Read<int>(addressFound) - (int)pm.BaseAddress) + offset);
                        else
                            return new IntPtr(Read<int>(addressFound) + offset);
                    } else {
                        if (subtract)
                            return new IntPtr((addressFound - (int)pm.BaseAddress) + offset);
                        else
                            return new IntPtr(addressFound + offset);
                    }
                }
            }
            return IntPtr.Zero;
        }

        /// <summary>
        /// Check the sig at the position off in memory.
        /// </summary>
        /// <param name="off">Position - Offset in buffer</param>
        /// <param name="byteSig">Sig in bytes, eg. {0xAC, 0x01, 0x0, 0x0, 0xA5}</param>
        /// <param name="pattern">Mask in chars, eg. {'x', 'x', '?', '?', 'x'}</param>
        /// <param name="dump">Dump of the memory to compare with</param>
        /// <returns></returns>
        private bool check(int off, byte[] byteSig, char[] pattern, byte[] dump) {
            if (pattern.Length <= 0 && byteSig.Length <= 0 && dump.Length <= 0 && pattern.Length <= 0 && pattern.Length != byteSig.Length)
                return false;

            for (int i = 0; i < pattern.Length; i++) {
                if (pattern[i] == 'x' && byteSig[i] != dump[off + i])
                    return false;
            }
            return true;
        }
        #endregion
    }
}
