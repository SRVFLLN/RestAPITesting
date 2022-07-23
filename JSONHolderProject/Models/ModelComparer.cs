using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace JSONHolderProject.Models
{
    public class ModelComparer : IComparer
    {
        int IComparer.Compare(object x, object y) 
        {
            IResource resource1 = (IResource)x;
            IResource resource2 = (IResource)y;
            if (resource1.Id > resource2.Id)
                return 1;
            if (resource1.Id < resource2.Id)
                return -1;
            else 
                return 0;
        }
    }
}
