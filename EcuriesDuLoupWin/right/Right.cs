using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EcuriesDuLoupWin.right.type;

namespace EcuriesDuLoupWin.right
{
    public class Right
    {
        
        public  static Right ADMINISTRATOR_PHOTO = new AdministratorPhoto();

        public static Right GetRight(String label)
        {
            if(label.Equals(ADMINISTRATOR_PHOTO.Label)){
                return ADMINISTRATOR_PHOTO;
            }

            return null;
        }

        protected Right()
        {

        }

        public String Label { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Right right = (Right)obj;
            return right.Label.Equals(this.Label);
        }

        public override int GetHashCode()
        {
            return this.Label.GetHashCode();
        }
    }
}
