﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Categorizer.Web {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class LocalizationStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LocalizationStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Categorizer.Web.LocalizationStrings", typeof(LocalizationStrings).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please put your text in area below or select file from your disk..
        /// </summary>
        public static string ErrorUploadedTextIsNotFount {
            get {
                return ResourceManager.GetString("ErrorUploadedTextIsNotFount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Some of your uploading texts aren&apos;t belong to existing categories..
        /// </summary>
        public static string ErrorUploadingTextIsNotCategorized {
            get {
                return ResourceManager.GetString("ErrorUploadingTextIsNotCategorized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File input 1.
        /// </summary>
        public static string FieldFileInput1 {
            get {
                return ResourceManager.GetString("FieldFileInput1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File input 2.
        /// </summary>
        public static string FieldFileInput2 {
            get {
                return ResourceManager.GetString("FieldFileInput2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Text.
        /// </summary>
        public static string FieldText {
            get {
                return ResourceManager.GetString("FieldText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Text has been defined like a {0}.
        /// </summary>
        public static string SuccessTextSuccessfullyAdded {
            get {
                return ResourceManager.GetString("SuccessTextSuccessfullyAdded", resourceCulture);
            }
        }
    }
}
