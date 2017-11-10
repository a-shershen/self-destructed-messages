using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MessageService
    {
        //DAL Repository
        DAL.IRepositiry<DAL.Message> messageRep;

        //Constructor
        public MessageService()
        {
            messageRep = new DAL.MessageRepositiry();
        }
              
        //Start Timer for remove over time messages
        public void RemoverTimer()
        {
            ExtFunc.Listener.StartTimer(messageRep);
        }

        //Add new message
        public string AddNewMessage(string text, int? timesToShow, DateTime timeToDele, string pass)
        {            
            try
            {
                //Hash link
                string hashLink = ExtFunc.Hash.GetLinkHash(
                    ExtFunc.LinkGenerator.Generate(32));

                int id = messageRep.GetMaxID();

                //Encrypt Message
                text = ExtFunc.Cryptograph.EncryptMessage(text, pass);

                //Create new instance of message
                DAL.Message message = new DAL.Message(id, text, timesToShow, hashLink, timeToDele);
                
                //Write new message in DB
                messageRep.AddNewMessage(message);

                //return result hash link
                return hashLink;
            }

            catch(Exception ex)
            {                
                throw ex;
            }
        }

        //Read message by its hash link
        public string ReadMessage(string hashLink, string pass)
        {            
            try
            {
                //Get message from DB by hashlink
                //Encrypt message
                return ExtFunc.Cryptograph.DecryptMessage(messageRep.GetMessage(hashLink), pass);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Collection of user agent names
        private List<string> userAgents = new List<string>(new string[]
        {        
            "skype", "vk.com", "ok.ru", "facebook", "fban", "facebot",
            "telegram", "viber", "twitter", "google", "bbm", "blackberry",
            "google", "signal", "whatsapp", "jabber"
        }); 

        //Check for user agents from list
        public bool IsItMessengerUserAgent(string agent)
        {
            foreach (var uAg in userAgents)
            {
                if (agent.ToLower().Contains(uAg.ToLower()))
                {
                    //return if user agent found in list
                    return true;
                }
            }

            //return if user agent not found in list
            return false;
        }
    }
}
