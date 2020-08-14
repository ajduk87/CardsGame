﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CardsGameServerQuery.Repositories.Sql {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class PlayerQueries {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PlayerQueries() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CardsGameServerQuery.Repositories.Sql.PlayerQueries", typeof(PlayerQueries).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM cardsgame.players.
        /// </summary>
        internal static string SelectAll {
            get {
                return ResourceManager.GetString("SelectAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT players.Id as PlayerId, players.Name as PlayerName, gamesteps.cardvalue as CardValue, players.playingpile as PlayingPile, players.discardpile as DiscardPile, gamesteps.cardsleft as CardsLeft
        ///FROM cardsgame.players players
        ///INNER JOIN cardsgame.games games on players.id = games.playerid
        ///INNER JOIN cardsgame.gamesteps gamesteps on games.playerid = gamesteps.playerid
        ///WHERE games.name = @gamename
        ///ORDER BY gamesteps.id
        ///LIMIT @numberOfPlayers;.
        /// </summary>
        internal static string SelectByGameName {
            get {
                return ResourceManager.GetString("SelectByGameName", resourceCulture);
            }
        }
    }
}
