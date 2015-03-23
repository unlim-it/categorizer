namespace Categorizer.Services.Support
{
    using System;
    using System.ServiceModel.Configuration;

    public class JsonErrorWebHttpBehaviorElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get
            {
                return typeof(JsonErrorWebHttpBehavior);
            }
        }

        protected override object CreateBehavior()
        {
            return new JsonErrorWebHttpBehavior();
        }
    }
}