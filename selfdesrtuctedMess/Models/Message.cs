using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace selfdestructedMess.Models
{
    //Model for View
    public class Message
    {
        [Required]
        public String Text { get; set; }
        
        public int? TimesToShow { get; set; }
        public int Minutes { get; set; }
    }

    //Model Binder
    public class ModelBinder:System.Web.Mvc.IModelBinder
    {
        public object BindModel(System.Web.Mvc.ControllerContext controllerContext,
            System.Web.Mvc.ModelBindingContext bindingContext)
        {
            var valueProvider = bindingContext.ValueProvider;

            Message mes = new Message();

            mes.Text = (string)valueProvider.GetValue("Text").ConvertTo(typeof(string));            

            try
            {
                mes.TimesToShow = (int)valueProvider.GetValue("TimesToShow").ConvertTo(typeof(int));
            }

            catch
            {
                mes.TimesToShow = null;
            }
                        
            mes.Minutes = (int)valueProvider.GetValue("Minutes").ConvertTo(typeof(int));           
            

            return mes;
        }
    }
}