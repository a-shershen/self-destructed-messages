using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DAL
{
    //Messare Repository Class
    public class MessageRepositiry : IRepositiry<Message>
    {
        //Returns max ID
        public int GetMaxID()
        {
            using(MessageContext context = new MessageContext())
            {
                int max = 0;

                if(context.Messages.Count()!=0)
                {                    
                    try
                    {
                        max = context.Messages.Max(m => m.Id);
                    }
                    catch(Exception ex)
                    {

                    }
                }

                max++;

                return max;
            }
        }

        //Add new Message
        public void AddNewMessage(Message message)
        {
            using (MessageContext context = new MessageContext())
            {
                try
                {
                    context.Messages.Add(message);
                    context.SaveChanges();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        //Returns message by hash link
        public string GetMessage(string hashLink)
        {
            using(MessageContext context = new MessageContext())
            {
                try
                {
                    //return message if it found
                    var message = context.Messages.Where(m => m.HashLink == hashLink).First();

                    //if time is ton over
                    if(DateTime.Compare(DateTime.Now, message.TimeToDelete) < 0)
                    {
                        //if message is allowed to show
                        if(!message.TimesToShow.HasValue || message.TimesToShow>0)
                        {
                            if(message.TimesToShow.HasValue)
                            {
                                //
                                message.TimesToShow--;

                                //If times to show is zero delete from DB
                                if(message.TimesToShow==0)
                                {
                                    string text = message.Text;
                                    RemoveFromDB(context, message);
                                    return text;
                                }
                            }

                            //Update DB
                            UpdateDBEntity(context, message);

                            return message.Text;

                        }

                        else
                        {
                            RemoveFromDB(context, message);
                            throw new Exception("TimesToShowIsOver");
                        }

                    }

                    else
                    {
                        RemoveFromDB(context, message);

                        throw new Exception("TimeIsOver");
                    }
                }

                catch (ArgumentException argExp)
                {
                    throw argExp;
                }

                catch (InvalidOperationException invOpEx)
                {
                    throw invOpEx;
                }

                catch(Exception ex)
                {
                    throw ex;
                }

            }
        }

        //Remove from DB
        private void RemoveFromDB(MessageContext context, Message message)
        {            
            context.Messages.Remove(message);
            context.SaveChanges();
        }

        //Update DB
        private void UpdateDBEntity(MessageContext context, Message message)
        {
            context.Entry(message).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        //Delete messages which time is over
        public void DeleteAllOverTimeMessages()
        {
            using(MessageContext context = new MessageContext())
            {
                try
                {
                    //Try to find all messages which time is over
                    var res = 
                        context.Messages.Where(m => DateTime.Compare(DateTime.Now, m.TimeToDelete) > 0);
                    
                    //Remove time over messages from DB
                    context.Messages.RemoveRange(res);
                    context.SaveChanges();
                }

                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
