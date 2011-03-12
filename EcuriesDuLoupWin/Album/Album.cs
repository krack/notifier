using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcuriesDuLoupWin.Album
{
    public class Album
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Display { get { return this.Id + " - " + this.Name; } private set { } }

        public override string ToString()
        {
            return "album : "+this.Id +",  "+this.Name+", " +base.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Album album = (Album)obj;
            return album.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
