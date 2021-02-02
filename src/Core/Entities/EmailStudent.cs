using System;

namespace Core.Entities
{
    public class EmailStudent
    {
        public string AdressEmail { get; init; }
        public string Name { get; init; }
        public string Subject { get; init; }
        public string BodyMessage { get; init; }
        public bool EmailHasBeenSent { get; private set; }

        public void MarkEmailSent()
        {
            EmailHasBeenSent = true;
        }
    }
}
