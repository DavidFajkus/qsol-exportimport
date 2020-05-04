using System;
using qsol.exportimport.Helpers;

namespace qsol.exportimport.Interface
{
    public interface IMainViewModel
    {
        event EventHandler<PasswordEventArgs> SourcePasswordEvent;
        event EventHandler<PasswordEventArgs> DestinationPasswordEvent;
    }
}
