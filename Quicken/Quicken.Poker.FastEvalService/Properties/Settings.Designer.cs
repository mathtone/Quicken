﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quicken.Poker.FastEvalService.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Settings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Settings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Quicken.Poker.FastEvalService.Properties.Settings", typeof(Settings).Assembly);
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
        ///   Looks up a localized string similar to Number of cards must equal 5.
        /// </summary>
        internal static string Error_Cards_Not_5 {
            get {
                return ResourceManager.GetString("Error_Cards_Not_5", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Input is null or empty.
        /// </summary>
        internal static string Error_Cards_NullOrEmpty {
            get {
                return ResourceManager.GetString("Error_Cards_NullOrEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Flush.
        /// </summary>
        internal static string HandClass_Flush {
            get {
                return ResourceManager.GetString("HandClass_Flush", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Full House.
        /// </summary>
        internal static string HandClass_FullHouse {
            get {
                return ResourceManager.GetString("HandClass_FullHouse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to High Card.
        /// </summary>
        internal static string HandClass_HighCard {
            get {
                return ResourceManager.GetString("HandClass_HighCard", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to One Pair.
        /// </summary>
        internal static string HandClass_OnePair {
            get {
                return ResourceManager.GetString("HandClass_OnePair", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Four of a Kind.
        /// </summary>
        internal static string HandClass_Quads {
            get {
                return ResourceManager.GetString("HandClass_Quads", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Straight.
        /// </summary>
        internal static string HandClass_Straight {
            get {
                return ResourceManager.GetString("HandClass_Straight", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Straight Flush.
        /// </summary>
        internal static string HandClass_StraightFlush {
            get {
                return ResourceManager.GetString("HandClass_StraightFlush", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Three of a kind.
        /// </summary>
        internal static string HandClass_Trips {
            get {
                return ResourceManager.GetString("HandClass_Trips", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Two Pairs.
        /// </summary>
        internal static string HandClass_TwoPair {
            get {
                return ResourceManager.GetString("HandClass_TwoPair", resourceCulture);
            }
        }
    }
}
