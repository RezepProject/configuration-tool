﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConfigurationTool.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ApplicationResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ApplicationResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ConfigurationTool.Resources.ApplicationResource", typeof(ApplicationResource).Assembly);
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
        ///   Looks up a localized string similar to Answer.
        /// </summary>
        public static string Answer {
            get {
                return ResourceManager.GetString("Answer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please enter a answer with a minimum of 10 characters.
        /// </summary>
        public static string ErrorTextAnswer {
            get {
                return ResourceManager.GetString("ErrorTextAnswer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pleace enter at least 10 characters.
        /// </summary>
        public static string ErrorTextInputQuestionManagment {
            get {
                return ResourceManager.GetString("ErrorTextInputQuestionManagment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please enter a question with a minimum of 10 characters.
        /// </summary>
        public static string ErrorTextQuestion {
            get {
                return ResourceManager.GetString("ErrorTextQuestion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hello Welcome to Rezep.
        /// </summary>
        public static string Greating {
            get {
                return ResourceManager.GetString("Greating", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Language.
        /// </summary>
        public static string Language {
            get {
                return ResourceManager.GetString("Language", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pepper settings.
        /// </summary>
        public static string PepperSettings {
            get {
                return ResourceManager.GetString("PepperSettings", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Question.
        /// </summary>
        public static string Question {
            get {
                return ResourceManager.GetString("Question", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Question Management.
        /// </summary>
        public static string QuestionsManagement {
            get {
                return ResourceManager.GetString("QuestionsManagement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Settings.
        /// </summary>
        public static string Settings {
            get {
                return ResourceManager.GetString("Settings", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Welcome to Rezep. In on this website you can change your Rezep-Settings or manage your questions..
        /// </summary>
        public static string WelcomeMessageText {
            get {
                return ResourceManager.GetString("WelcomeMessageText", resourceCulture);
            }
        }
    }
}
