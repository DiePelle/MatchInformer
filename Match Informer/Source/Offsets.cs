using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MatchInformer.Source.UI;

namespace MatchInformer.Source {
    public class Offsets {
        #region Definitions - MOVE THIS TO SDK LATER ON
        public enum EClassIds
        {
            CAI_BaseNPC = 0,
            CAK47,
            CBaseAnimating,
            CBaseAnimatingOverlay,
            CBaseAttributableItem,
            CBaseButton,
            CBaseCombatCharacter,
            CBaseCombatWeapon,
            CBaseCSGrenade,
            CBaseCSGrenadeProjectile,
            CBaseDoor,
            CBaseEntity,
            CBaseFlex,
            CBaseGrenade,
            CBaseParticleEntity,
            CBasePlayer,
            CBasePropDoor,
            CBaseTeamObjectiveResource,
            CBaseTempEntity,
            CBaseToggle,
            CBaseTrigger,
            CBaseViewModel,
            CBaseVPhysicsTrigger,
            CBaseWeaponWorldModel,
            CBeam,
            CBeamSpotlight,
            CBoneFollower,
            CBreakableProp,
            CBreakableSurface,
            CC4,
            CCascadeLight,
            CChicken,
            CColorCorrection,
            CColorCorrectionVolume,
            CCSGameRulesProxy,
            CCSPlayer,
            CCSPlayerResource,
            CCSRagdoll,
            CCSTeam,
            CDEagle,
            CDecoyGrenade,
            CDecoyProjectile,
            CDynamicLight,
            CDynamicProp,
            CEconEntity,
            CEconWearable,
            CEmbers,
            CEntityDissolve,
            CEntityFlame,
            CEntityFreezing,
            CEntityParticleTrail,
            CEnvAmbientLight,
            CEnvDetailController,
            CEnvDOFController,
            CEnvParticleScript,
            CEnvProjectedTexture,
            CEnvQuadraticBeam,
            CEnvScreenEffect,
            CEnvScreenOverlay,
            CEnvTonemapController,
            CEnvWind,
            CFEPlayerDecal,
            CFireCrackerBlast,
            CFireSmoke,
            CFireTrail,
            CFish,
            CFlashbang,
            CFogController,
            CFootstepControl,
            CFunc_Dust,
            CFunc_LOD,
            CFuncAreaPortalWindow,
            CFuncBrush,
            CFuncConveyor,
            CFuncLadder,
            CFuncMonitor,
            CFuncMoveLinear,
            CFuncOccluder,
            CFuncReflectiveGlass,
            CFuncRotating,
            CFuncSmokeVolume,
            CFuncTrackTrain,
            CGameRulesProxy,
            CHandleTest,
            CHEGrenade,
            CHostage,
            CHostageCarriableProp,
            CIncendiaryGrenade,
            CInferno,
            CInfoLadderDismount,
            CInfoOverlayAccessor,
            CItem_Healthshot,
            CKnife,
            CKnifeGG,
            CLightGlow,
            CMaterialModifyControl,
            CMolotovGrenade,
            CMolotovProjectile,
            CMovieDisplay,
            CParticleFire,
            CParticlePerformanceMonitor,
            CParticleSystem,
            CPhysBox,
            CPhysBoxMultiplayer,
            CPhysicsProp,
            CPhysicsPropMultiplayer,
            CPhysMagnet,
            CPlantedC4,
            CPlasma,
            CPlayerResource,
            CPointCamera,
            CPointCommentaryNode,
            CPoseController,
            CPostProcessController,
            CPrecipitation,
            CPrecipitationBlocker,
            CPredictedViewModel,
            CProp_Hallucination,
            CPropDoorRotating,
            CPropJeep,
            CPropVehicleDriveable,
            CRagdollManager,
            CRagdollProp,
            CRagdollPropAttached,
            CRopeKeyframe,
            CSCAR17,
            CSceneEntity,
            CSensorGrenade,
            CSensorGrenadeProjectile,
            CShadowControl,
            CSlideshowDisplay,
            CSmokeGrenade,
            CSmokeGrenadeProjectile,
            CSmokeStack,
            CSpatialEntity,
            CSpotlightEnd,
            CSprite,
            CSpriteOriented,
            CSpriteTrail,
            CStatueProp,
            CSteamJet,
            CSun,
            CSunlightShadowControl,
            CTeam,
            CTeamplayRoundBasedRulesProxy,
            CTEArmorRicochet,
            CTEBaseBeam,
            CTEBeamEntPoint,
            CTEBeamEnts,
            CTEBeamFollow,
            CTEBeamLaser,
            CTEBeamPoints,
            CTEBeamRing,
            CTEBeamRingPoint,
            CTEBeamSpline,
            CTEBloodSprite,
            CTEBloodStream,
            CTEBreakModel,
            CTEBSPDecal,
            CTEBubbles,
            CTEBubbleTrail,
            CTEClientProjectile,
            CTEDecal,
            CTEDust,
            CTEDynamicLight,
            CTEEffectDispatch,
            CTEEnergySplash,
            CTEExplosion,
            CTEFireBullets,
            CTEFizz,
            CTEFootprintDecal,
            CTEFoundryHelpers,
            CTEGaussExplosion,
            CTEGlowSprite,
            CTEImpact,
            CTEKillPlayerAttachments,
            CTELargeFunnel,
            CTEMetalSparks,
            CTEMuzzleFlash,
            CTEParticleSystem,
            CTEPhysicsProp,
            CTEPlantBomb,
            CTEPlayerAnimEvent,
            CTEPlayerDecal,
            CTEProjectedDecal,
            CTERadioIcon,
            CTEShatterSurface,
            CTEShowLine,
            CTesla,
            CTESmoke,
            CTESparks,
            CTESprite,
            CTESpriteSpray,
            CTest_ProxyToggle_Networkable,
            CTestTraceline,
            CTEWorldDecal,
            CTriggerPlayerMovement,
            CTriggerSoundOperator,
            CVGuiScreen,
            CVoteController,
            CWaterBullet,
            CWaterLODControl,
            CWeaponAug,
            CWeaponAWP,
            CWeaponBaseItem,
            CWeaponBizon,
            CWeaponCSBase,
            CWeaponCSBaseGun,
            CWeaponCycler,
            CWeaponElite,
            CWeaponFamas,
            CWeaponFiveSeven,
            CWeaponG3SG1,
            CWeaponGalil,
            CWeaponGalilAR,
            CWeaponGlock,
            CWeaponHKP2000,
            CWeaponM249,
            CWeaponM3,
            CWeaponM4A1,
            CWeaponMAC10,
            CWeaponMag7,
            CWeaponMP5Navy,
            CWeaponMP7,
            CWeaponMP9,
            CWeaponNegev,
            CWeaponNOVA,
            CWeaponP228,
            CWeaponP250,
            CWeaponP90,
            CWeaponSawedoff,
            CWeaponSCAR20,
            CWeaponScout,
            CWeaponSG550,
            CWeaponSG552,
            CWeaponSG556,
            CWeaponSSG08,
            CWeaponTaser,
            CWeaponTec9,
            CWeaponTMP,
            CWeaponUMP45,
            CWeaponUSP,
            CWeaponXM1014,
            CWorld,
            DustTrail,
            MovieExplosion,
            ParticleSmokeGrenade,
            RocketTrail,
            SmokeTrail,
            SporeExplosion,
            SporeTrail,

        };
        public struct Player
        {
            public int index;
            public string name;

            public string steamID;
            public int steamID3;
            public Int64 steamID64;
            public string profileLink;

            public int winCount;
            public int rank;

        }
        public static string[] RANKS = new string[] {
            "No Rank",

            "Silver I",
            "Silver II",
            "Silver III",
            "Silver IV",
            "Silver Elite",
            "Silver Elite Master",

            "Gold Nova I",
            "Gold Nova II",
            "Gold Nova III",
            "Gold Nova Master",

            "Master Guardian I",
            "Master Guardian II",
            "Master Guardian Elite",

            "Distinguished Master Guardian",
            "Legendary Eagle",
            "Legendary Eagle Master",
            "Supreme Master First Class",
            "The Global Elite"
        };

        //CREDIT: https://www.unknowncheats.me/forum/counterstrike-global-offensive/217871-getplayerinfo-external.html
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct player_info_s
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public char[] __pad0;
            public int m_nXuidLow;
            public int m_nXuidHigh;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            public char[] m_szPlayerName;
            public int m_nUserID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
            public char[] m_szSteamID;
            public uint m_nSteam3ID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            public char[] m_szFriendsName;
            [MarshalAs(UnmanagedType.U1, SizeConst = 1)]
            public bool m_bIsFakePlayer;
            [MarshalAs(UnmanagedType.U1, SizeConst = 1)]
            public bool m_bIsHLTV;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public int[] m_dwCustomFiles;
            public char m_FilesDownloaded;
        }
        #endregion

        Memory mem = Memory.Instance;

        public Offsets() { }

        #region Utils
        public void RenewOffsets() {
            competitiveRanking = new IntPtr(0x1A44);
            competitiveWins = new IntPtr(0x1B48);

            localPlayer = mem.Read<IntPtr>(mem.client.BaseAddress.ToInt32() + dwLocalPlayer.ToInt32());
            clientState = mem.Read<IntPtr>(mem.engine.BaseAddress.ToInt32() + dwClientState.ToInt32());
            entityList = new IntPtr(mem.client.BaseAddress.ToInt32() + dwEntityList.ToInt32());
            playerRessource = mem.Read<IntPtr>(mem.client.BaseAddress.ToInt32() + dwPlayerResource.ToInt32());
        }

        #region Player Related
        /// <summary>
        /// Loops through the max clients possible on server and adds them to the list if they are valid
        /// </summary>
        /// <param name="ignoreBots">Should bots be ignored?</param>
        /// <returns>List with Players</returns>
        public List<Player> GetPlayers(bool ignoreBots, MainWindow.FilterTypes filter) {
            List<Player> temp = new List<Player>();

            for (int i = 1; i < mem.Read<int>(GetClientState().ToInt32() + GetClientStateMaxPlayer().ToInt32()); i++) {
                int index = i - 1;
                IntPtr ent = GetEntityByIndex(index);
                if (!IsPlayer(ent) 
                    || (filter == MainWindow.FilterTypes.CT && mem.Read<int>(ent.ToInt32() + 0xF0) != 3) 
                    || (filter == MainWindow.FilterTypes.T && mem.Read<int>(ent.ToInt32() + 0xF0) != 2)) continue;
                player_info_s info = GetPlayerInfo(index);

                if (ignoreBots && info.m_nSteam3ID == 0)
                    continue;

                temp.Add(new Player {
                    index = index,
                    name = (info.m_nSteam3ID == 0 ? "(BOT) " : "") + new string(info.m_szPlayerName, 0, 128).Replace("\0", ""),

                    steamID = info.m_nSteam3ID != 0 ? new string(info.m_szSteamID, 0, 33).Replace("\0", "") : "0",
                    steamID3 = (int)info.m_nSteam3ID,
                    steamID64 = info.m_nSteam3ID != 0 ? GetSteamID64(new string(info.m_szSteamID, 0, 33).Replace("\0", "")) : 0,
                    profileLink = info.m_nSteam3ID != 0 ? "http://steamcommunity.com/profiles/" + GetSteamID64(new string(info.m_szSteamID, 0, 33).Replace("\0", "")) : "It is a bot, it has no profile...!",

                    winCount = GetWins(index),
                    rank = GetRank(index)
                });                
            }

            if (temp.Count > 0)
                return temp;
            else
                return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr">Entity</param>
        /// <returns>EClassIDs</returns>
        public int GetClassID(IntPtr ptr) {
            return mem.Read<int>(mem.Read<int>(mem.Read<int>(mem.Read<int>(ptr.ToInt32() + 0x8) + 0x8) + 0x1) + 0x14);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Address</returns>
        public IntPtr GetEntityByIndex(int i) {
            return mem.Read<IntPtr>(GetEntityList().ToInt32() + ((i - 1) * 0x10));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr">Entity</param>
        /// <returns>
        /// true: Is Player
        /// false: No Player
        /// </returns>
        public bool IsPlayer(IntPtr ptr) {
            int id = GetClassID(ptr);
            return id == (int)EClassIds.CCSPlayer || id == (int)EClassIds.CBasePlayer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Win count</returns>
        public int GetWins(int index) => mem.Read<int>(GetPlayerRessource().ToInt32() + CompetitiveWins.ToInt32() + (index * 4));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Rank from 0 to 18</returns>
        public int GetRank(int index) => mem.Read<int>(GetPlayerRessource().ToInt32() + GetCompetitiveRanking().ToInt32() + (index * 4));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="steamID3">SteamID3</param>
        /// <returns>SteamID64</returns>
        public Int64 GetSteamID64(string steamID3) => (int.Parse(steamID3.Substring(10)) * 2 + 76561197960265728 + int.Parse(steamID3.Substring(8, 1))); //Reference: https://developer.valvesoftware.com/wiki/SteamID

        //COPY PASTA-> CREDIT: https://www.unknowncheats.me/forum/counterstrike-global-offensive/217871-getplayerinfo-external.html
        public IntPtr GetUserInfoTable() {
            return mem.Read<IntPtr>(GetClientState().ToInt32() + GetClientStateInfo().ToInt32());
        }
        public player_info_s GetPlayerInfo(int index) {
            var items = mem.Read<IntPtr>(mem.Read<IntPtr>(GetUserInfoTable().ToInt32() + 0x3C).ToInt32() + 0xC);
            return mem.Read<player_info_s>(mem.Read<IntPtr>(items.ToInt32() + 0x20 + ((index - 1) * 0x34)).ToInt32());
        }
        #endregion

        #region General
        /// <summary>
        /// Checks if player is ingame
        /// </summary>
        /// <returns>
        /// true: Player is ingame
        /// false: Player is not ingame
        /// </returns>
        public bool IsIngame() {
            return (mem.Read<int>(GetClientState().ToInt32() + 0x108) == 6);
        }
        #endregion

        /// <summary>
        /// Initializes the vars
        /// </summary>
        /// <returns>
        /// true:   all offsets were found
        /// false:  at least one offset were not found
        /// </returns>
        public bool PatternScan() {
            if ((revealAllFuncAddr = mem.FindPattern("client.dll", "55 8B EC 8B 0D ? ? ? ? 68", 0, 0, false, false)) == IntPtr.Zero) return false;
            if ((dwLocalPlayer = mem.FindPattern("client.dll", "A3 ? ? ? ? C7 05 ? ? ? ? ? ? ? ? E8 ? ? ? ? 59 C3 6A ?", 1, 16, true, true)) == IntPtr.Zero) return false;
            if ((dwClientState = mem.FindPattern("engine.dll", "A1 ? ? ? ? 33 D2 6A 00 6A 00 33 C9 89 B0", 1, 0, true, true)) == IntPtr.Zero) return false;
            if ((dwClientState_PlayerInfo = mem.FindPattern("engine.dll", "8B 89 ? ? ? ? 85 C9 0F 84 ? ? ? ? 8B 01", 2, 0, true, false)) == IntPtr.Zero) return false;
            if ((dwClientState_MaxPlayer = mem.FindPattern("engine.dll", "A1 ? ? ? ? 8B 80 ? ? ? ? C3 CC CC CC CC 55 8B EC 8A 45 08", 7, 0, true, false)) == IntPtr.Zero) return false;
            if ((dwClientState_State = mem.FindPattern("engine.dll", "83 B8 ? ? ? ? ? 0F 94 C0 C3", 2, 0, true, false)) == IntPtr.Zero) return false;
            if ((dwEntityList = mem.FindPattern("client.dll", "BB ? ? ? ? 83 FF 01 0F 8C ? ? ? ? 3B F8", 1, 0, true, true)) == IntPtr.Zero) return false;
            if ((dwPlayerResource = mem.FindPattern("client.dll", "8B 3D ? ? ? ? 85 FF 0F 84 ? ? ? ? 81 C7", 2, 0, true, true)) == IntPtr.Zero) return false;
            return true;
        }
        #endregion

        #region Offsets
        //"dwLocalPlayer": {
        //  "extra": 1,
        //  "mode_read": true,
        //  "mode_subtract": true,
        //  "module": "client.dll",
        //  "offset": 16,
        //  "pattern": "A3 ? ? ? ? C7 05 ? ? ? ? ? ? ? ? E8 ? ? ? ? 59 C3 6A ?"
        //},
        private IntPtr dwLocalPlayer = IntPtr.Zero,
            localPlayer; //SCAN
        public IntPtr GetLocalPlayer() => localPlayer;

        //"dwClientState": {
        //  "extra": 1,
        //  "mode_read": true,
        //  "mode_subtract": true,
        //  "module": "engine.dll",
        //  "offset": 0,
        //  "pattern": "A1 ? ? ? ? 33 D2 6A 00 6A 00 33 C9 89 B0"
        //},
        private IntPtr dwClientState = IntPtr.Zero,
            clientState; //SCAN
        public IntPtr GetClientState() => clientState;

        //"dwClientState_PlayerInfo": {
        //  "extra": 2,
        //  "mode_read": true,
        //  "mode_subtract": false,
        //  "module": "engine.dll",
        //  "offset": 0,
        //  "pattern": "8B 89 ? ? ? ? 85 C9 0F 84 ? ? ? ? 8B 01"
        //},
        private IntPtr dwClientState_PlayerInfo = IntPtr.Zero;
        public IntPtr GetClientStateInfo() => dwClientState_PlayerInfo;

        //"dwClientState_MaxPlayer": {
        //  "extra": 7,
        //  "mode_read": true,
        //  "mode_subtract": false,
        //  "module": "engine.dll",
        //  "offset": 0,
        //  "pattern": "A1 ? ? ? ? 8B 80 ? ? ? ? C3 CC CC CC CC 55 8B EC 8A 45 08"
        //},
        private IntPtr dwClientState_MaxPlayer = IntPtr.Zero;
        public IntPtr GetClientStateMaxPlayer() => dwClientState_MaxPlayer;

        //"dwClientState_State": {
        //  "extra": 2,
        //  "mode_read": true,
        //  "mode_subtract": false,
        //  "module": "engine.dll",
        //  "offset": 0,
        //  "pattern": "83 B8 ? ? ? ? ? 0F 94 C0 C3"
        //},
        private IntPtr dwClientState_State = IntPtr.Zero;
        public IntPtr GetClientState_State() => dwClientState_State;

        //"dwEntityList": {
        //  "extra": 1,
        //  "mode_read": true,
        //  "mode_subtract": true,
        //  "module": "client.dll",
        //  "offset": 0,
        //  "pattern": "BB ? ? ? ? 83 FF 01 0F 8C ? ? ? ? 3B F8"
        //},
        private IntPtr dwEntityList = IntPtr.Zero,
            entityList; //SCAN
        public IntPtr GetEntityList() => entityList;

        //"dwPlayerResource": {
        //  "extra": 2,
        //  "mode_read": true,
        //  "mode_subtract": true,
        //  "module": "client.dll",
        //  "offset": 0,
        //  "pattern": "8B 3D ? ? ? ? 85 FF 0F 84 ? ? ? ? 81 C7"
        //},
        private IntPtr dwPlayerResource = IntPtr.Zero,
            playerRessource; //SCAN
        public IntPtr GetPlayerRessource() => playerRessource;

        private IntPtr competitiveRanking;
        public IntPtr GetCompetitiveRanking() => competitiveRanking;

        private IntPtr competitiveWins;
        public IntPtr CompetitiveWins => competitiveWins;

        //"revealAllFuncAddr": {
        //  "extra": 0,
        //  "mode_read": false,
        //  "mode_subtract": false,
        //  "module": "client.dll",
        //  "offset": 0,
        //  "pattern": "55 8B EC 8B 0D ? ? ? ? 68"
        //},
        private IntPtr revealAllFuncAddr = IntPtr.Zero;
        public IntPtr GetReavealRank() => revealAllFuncAddr;
        #endregion
    }
}
