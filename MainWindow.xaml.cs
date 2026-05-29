using System.Speech.Synthesis;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cyber_security_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentTopic = "";
        private string userName = "";


        Dictionary<string, List<string>> keywordGroups;
        Dictionary<string, string> responses;

        SpeechSynthesizer speech = new SpeechSynthesizer();

        public MainWindow()
        {
            InitializeComponent();

            //Voice Message
            speech.Rate = 0;
            speech.SelectVoice("Microsoft Mark");
            speech.Speak("“Hello! Welcome to the Cybersecurity Awareness Bot. I’m here to help you stay safe online.");

            //Keyword Groups Dictionary
            keywordGroups = new Dictionary<string, List<string>>(){

           { "identity", new List<string> { "what are you", "who are you", "what can you do" } },
           { "password", new List<string> { "password" } },
           { "phishing", new List<string> { "phishing", "scam", "social engineering", "suspicious links" } },
           { "malware", new List<string> { "malware", "virus", "ransomware" } },
           { "safe browsing", new List<string> { "safe browsing", "secure website" } },
           { "authentication", new List<string> { "authentication", "verification", "certification" } },
           { "hacking", new List<string> { "hacking", "cyber attack" } },
           { "wifi", new List<string> { "public wifi", "private wifi" } },
           { "vpn", new List<string> { "vpn", "virtual private network" } },
           { "dataBreach", new List<string> { "data breach", "cyber breach", "data leak" } },
           { "socialMedia", new List<string> { "facebook", "instagram", "tiktok", "social media", "posting" } },
           { "payment", new List<string> { "payment", "credit card", "debit card", "online shopping", "transaction" } },
           { "spam", new List<string> { "spam", "junk mail", "email scam", "inbox" } },
           { "apps", new List<string> { "apps", "applications", "install", "permissions" } },
           { "privacy", new List<string> { "personal data", "private information", "sensitive information", "privacy settings" } },
           { "safety", new List<string> { "safe", "safety" } },
           { "help", new List<string> { "help", "assist" } },
           { "deviceSecurity", new List<string> { "device security", "iot security" } },
           { "thanks", new List<string> { "thank you", "thanks", "okay" } },
           { "greeting", new List<string> { "hi", "hello", "hey", "yo" } },
           { "exit", new List<string> { "goodbye", "bye", "exit" } }
           };

            // Response Dictionary
            responses = new Dictionary<string, string>()
            {
                {
                    "identity",
                    "Bot: I am an automated software application programmed to provide you with any information related to CYBER SECURITY.\n\n" +
                "What I can help with:\n" +
                "- Explaining cybersecurity concepts\n" +
                "- Giving tips to stay safe online\n" +
                "- Answering questions about threats like malware and phishing\n" +
                "- Providing basic security best practices\n" +
                "- Helping you understand online risks and protection methods\n\n" +
                "Type 'help' or 'assist' for more information..."
                },

                {
                    "password",
                    "Bot: A strong password should be long (12+ characters), unique, and include letters, numbers, and symbols.\n\n" +
                "* Avoid using personal information like your name or birthday.\n" +
                "* Use different passwords for each account.\n" +
                "* Consider using a password manager for safety."
                },

                {
                    "phishing",
                    "Bot: Phishing is a cyberattack where scammers trick you into revealing personal or financial information through deceptive emails, messages, or websites.\n\n" +
                "How Phishing Works:\n" +
                "* Fake messages or websites appear legitimate\n" +
                "* Victims click links or enter credentials\n" +
                "* Attackers exploit trust and urgency"

                },

                {
                    "malware",
                    "Bot: Malware is malicious software designed to damage or exploit systems.\n\n" +
                "Key points:\n" +
                "- Includes viruses, worms, trojans, ransomware\n" +
                "- Can steal, damage, or lock data\n" +
                "- Avoid untrusted downloads\n" +
                "- Use antivirus software\n" +
                "- Keep backups"
                },

                {
                    "safe browsing",
                    "Bot: Safe browsing involves protecting your data while using the internet.\n\n" +
                "Key points:\n" +
                "* Use HTTPS websites\n" +
                "* Avoid suspicious links\n" +
                "* Don’t enter info on unknown sites\n" +
                "* Use secure browsers\n" +
                "* Log out on shared devices"
                },

                {
                    "authentication",
                    "Bot: Authentication is the process of verifying identity before granting access.\n\n" +
                "How it works:\n" +
                "1. Identification (username)\n" +
                "2. Authentication (password/MFA)\n" +
                "3. Authorization (permissions)"
                },

                {
                    "hacking",
                    "Bot: Hacking is unauthorized access to systems or networks to steal, damage, or alter data.\n\n" +
                "Key points:\n" +
                "- Use strong passwords\n" +
                "- Keep software updated\n" +
                "- Avoid suspicious emails\n" +
                "- Use antivirus\n" +
                "- Protect personal data"
                },

                {
                    "wifi",
                    "Bot: Public Wi-Fi can be risky while private Wi-Fi is more secure.\n\n" +
                "* Avoid sensitive logins on public Wi-Fi\n" +
                "* Use VPNs\n" +
                "* Disable auto-connect\n" +
                "* Use strong router passwords"
                },

                {
                    "vpn",
                    "Bot: A VPN encrypts your internet traffic and hides your IP address.\n\n" +
                "Benefits:\n" +
                "* Security\n" +
                "* Privacy\n" +
                "* Access restricted content"
                },

                {
                    "dataBreach",
                    "Bot: A data breach is when unauthorized users access sensitive or confidential data."
                },

                {
                    "socialMedia",
                    "Bot: Social media can expose personal data if not used carefully.\n\n" +
                "* Avoid oversharing\n" +
                "* Use privacy settings\n" +
                "* Beware fake accounts"
                },

                {
                    "payment",
                    "Bot: Only make payments on secure websites and never share banking details.\n\n" +
                "* Use HTTPS\n" +
                "* Don’t share card info\n" +
                "* Enable alerts\n" +
                "* Avoid public Wi-Fi"
                },

                {
                    "spam",
                    "Bot: Spam emails are unwanted messages that may contain scams or malware."
                },

                {
                    "apps",
                    "Bot: Only install apps from trusted sources and review permissions carefully."
                },

                {
                    "privacy",
                    "Bot: Protect your personal data and limit what you share online."
                },

                {
                    "safety",
                    "Bot: Staying safe online requires strong passwords, secure connections, and cautious behavior."
                },
                {
                    "help",
                    "Bot: I can help you with:\n" +
                "- Passwords\n" +
                "- Phishing\n" +
                "- Malware\n" +
                "- Safe Browsing\n" +
                "- Authentication\n" +
                "- VPN\n" +
                "- Hacking\n" +
                "- Device Security\n" +
                "- Social Media Safety"
                },

                {
                    "deviceSecurity",
                    "Bot: Device security protects phones, laptops, PCs, and IoT devices."
                },

                {
                    "thanks",
                    "Bot: You are welcome, anything else I can help you with?"
                },

                {
                    "greeting",
                    "Bot: Hi!"
                },

                {
                    "exit",
                    "Bot: Thank you for using the Cybersecurity Awareness Bot. Remember to stay safe online!"
                }

            };

            //method to display introduction
            DisplayWelcomeMessage();
        }

        //welcome method
        public void DisplayWelcomeMessage(){
            
            //Instructions
            ChatBox.AppendText("Bot: Here are the Instructions before we start!" + Environment.NewLine);

            ChatBox.AppendText("Instructions:" + Environment.NewLine);
            ChatBox.AppendText("- I can only answer questions related to CYBER SECURITY." + Environment.NewLine);
            ChatBox.AppendText("- I'm here to help you keep your information SAFE and Secure." + Environment.NewLine);
            ChatBox.AppendText("- Learn anything based on CYBER SECURITY." + Environment.NewLine);
            ChatBox.AppendText("- Type 'exit' to stop me from running." + Environment.NewLine);

            AppendMessage("Bot: Can i get your name please?", Brushes.Green);

        }



        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            // Gets the message entered by the user and converts it to lowercase
            string userMessage = UserInputBox.Text.Trim().ToLower();

            // Makes sure the user does not send an empty message
            if (string.IsNullOrWhiteSpace(userMessage))
            {
                AppendMessage("Bot: Please enter a message.", Brushes.Red);
                return;
            }

            // Saves the first message entered as the user's name
            if (string.IsNullOrEmpty(userName))
            {
                userName = userMessage;

                // Welcomes the user after entering their name
                AppendMessage("Bot: Welcome " + userName + "!", Brushes.Green);
                UserInputBox.Clear();

                return;
            }

            // Displays the user's message in the chatbox
            AppendMessage(userName + ": " + userMessage, Brushes.DarkGreen);

            // Sends the user's message to the chatbot response method
            string botResponse = GetBotResponse(userMessage);

            // Displays the chatbot's response in the chatbox
            AppendMessage(botResponse, Brushes.Green);

            // Closes the application if the user types "exit"
            if (userMessage == "exit")
            {
                Application.Current.Shutdown();
            }

            // Clears the textbox after sending the message
            UserInputBox.Clear();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            //Clears text on the RichTextBox
            ChatBox.Document.Blocks.Clear();
        }

        public string GetBotResponse(string userInput)
        {
            foreach (var topic in keywordGroups)
            {
                // This section checks how the user is feeling

                if (userInput.Contains("scared") || userInput.Contains("worried") || userInput.Contains("afraid"))
                {
                    return "Bot: Don't worry. Staying informed is the first step to cybersecurity safety.";
                }

                // Responds positively if the user seems happy
                if (userInput.Contains("happy") || userInput.Contains("good") || userInput.Contains("great"))
                {
                    return "Bot: I'm glad you're feeling good today!";
                }

                // Helps the user if they don't understand something
                if (userInput.Contains("confused") || userInput.Contains("lost"))
                {
                    return "Bot: That's okay. I'll try explain it more simply.";
                }

                // Tries to calm the user if they seem frustrated
                if (userInput.Contains("angry") || userInput.Contains("frustrated"))
                {
                    return "Bot: I understand that cybersecurity can sometimes be frustrating.";
                }

                // Encourages the user to learn more about cybersecurity
                if (userInput.Contains("curious") || userInput.Contains("interested"))
                {
                    return "Bot: That's great! Learning about cybersecurity helps you stay safe online.";
                }


                if (userInput.Contains("tell me more"))
                {

                    // more info about phishing
                    if (currentTopic == "phishing")
                    {
                        return "Bot: Phishing attacks often pretend to be banks, schools, or trusted companies.\n\n" +

                "***PHISHING EXAMPLES***\n" +
                "1. Email Phishing: Attackers send emails that appear legitimate to steal login cresedentials or personal Information\n" +
                "2. Spear Phishing: A target on a specific individual.\n" +
                "3. Vhishing: Attackers use phone calls to impersonate trusted figures\n" +
                "NOTE: Modern phishing can even target multi-factor authentication codes.\n\n" +

                "***PHISHING PREVENTION***\n" +
                "- Use multi-factor authentication (MFA) to secure your accounts. It adds an extra layer of security beyond passwords.\n" +
                "- Implement email security protocols such as SPF to prevent attackers from spoofing your domain.\n" +
                "- Avoid clicking on links or downloading attachments from unknown or unexpected sources.\n" +
                "- Regularly back up important data to external drives or cloud storage";
                    }


                    // more info about password
                    if (currentTopic == "password")
                    {
                        return "Bot: Password managers can help generate and store secure passwords.\n\n" +
                               "More password safety tips:\n" +
                               "- Use at least 12 characters\n" +
                               "- Combine uppercase, lowercase, numbers, and symbols\n" +
                               "- Never reuse passwords across accounts\n" +
                               "- Avoid using names or birthdays\n" +
                               "- Change compromised passwords immediately\n\n" +

                               "Extra protection:\n" +
                               "* Enable two-factor authentication (2FA)\n" +
                               "* Do not share passwords with anyone\n" +
                               "* Store passwords securely\n" +
                               "* Avoid writing passwords in public places";
                    }

                    //more info about MALWARE
                    if (currentTopic == "malware")
                    {
                        return "Bot: Malware can spread through downloads, email attachments, and fake apps.\n\n" +
                               "Types of malware:\n" +
                               "- Viruses\n" +
                               "- Worms\n" +
                               "- Trojans\n" +
                               "- Spyware\n" +
                               "- Ransomware\n\n" +

                               "Effects of malware:\n" +
                               "- Slows down devices\n" +
                               "- Steals personal information\n" +
                               "- Deletes or encrypts files\n" +
                               "- Monitors user activity\n\n" +

                               "Protection tips:\n" +
                               "* Install antivirus software\n" +
                               "* Avoid pirated software\n" +
                               "* Keep your system updated\n" +
                               "* Do not open suspicious files";
                    }


                    // more info about VPN
                    if (currentTopic == "vpn")
                    {
                        return "Bot: VPN stands for Virtual Private Network.\n\n" +
                               "More about VPNs:\n" +
                               "- VPNs encrypt internet traffic\n" +
                               "- They help protect your privacy online\n" +
                               "- VPNs are useful on public Wi-Fi\n" +
                               "- They hide your IP address from websites\n\n" +

                               "Benefits:\n" +
                               "* Safer browsing\n" +
                               "* Better online privacy\n" +
                               "* Reduced tracking\n" +
                               "* Protection against hackers on public networks";
                    }

                    // more info about HACKING
                    if (currentTopic == "hacking")
                    {
                        return "Bot: Hackers use different techniques to attack systems and steal information.\n\n" +
                               "Common hacking methods:\n" +
                               "- Phishing attacks\n" +
                               "- Malware infections\n" +
                               "- Password cracking\n" +
                               "- Social engineering\n\n" +

                               "How to stay protected:\n" +
                               "* Use strong passwords\n" +
                               "* Keep software updated\n" +
                               "* Avoid suspicious websites\n" +
                               "* Use antivirus software\n" +
                               "* Enable firewall protection";
                    }

                    // more info about SAFE BROWSING
                    if (currentTopic == "safe browsing")
                    {
                        return "Bot: Safe browsing helps protect your personal information online.\n\n" +
                               "Safe browsing practices:\n" +
                               "- Use HTTPS websites\n" +
                               "- Avoid suspicious links\n" +
                               "- Download files from trusted websites only\n" +
                               "- Log out from public devices\n\n" +

                               "Extra safety tips:\n" +
                               "* Keep browsers updated\n" +
                               "* Avoid pop-up scams\n" +
                               "* Use secure passwords\n" +
                               "* Never share personal details on unknown websites";
                    }

                    // more info about SOCIAL MEDIA
                    if (currentTopic == "socialMedia")
                    {
                        return "Bot: Social media can expose personal information if used carelessly.\n\n" +
                               "Online safety tips:\n" +
                               "- Avoid oversharing personal information\n" +
                               "- Be careful of fake accounts\n" +
                               "- Do not share your location publicly\n" +
                               "- Use privacy settings\n\n" +

                               "Cyber risks:\n" +
                               "* Identity theft\n" +
                               "* Online scams\n" +
                               "* Cyberbullying\n" +
                               "* Phishing attacks through messages";
                    }

                    // more info about FALLBACK
                    return "Bot: Please ask about a cybersecurity topic first so I can provide more information.";
                }


                foreach (string keyword in topic.Value)
                {
                    // Checks each keyword in the current topic
                    if (userInput.Contains(keyword))
                    {
                        // Saves the current topic so the chatbot can remember it later
                        currentTopic = topic.Key;

                        // Returns the response linked to the matched topic
                        return responses[topic.Key];
                    }
                }
            }
                // Displays this message if no keywords were found
                return "Bot: I'm not sure I understand.";
            }

        private void AppendMessage(string message, SolidColorBrush color)
        {
            // Creates a new text range inside the chatbox
            TextRange range = new TextRange(ChatBox.Document.ContentEnd, ChatBox.Document.ContentEnd);

            // Adds the message with a new line at the end
            range.Text = message + Environment.NewLine;

            // Changes the text color of the message
            range.ApplyPropertyValue(TextElement.ForegroundProperty, color);
        }
    }
    }
