using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Models.Models.Enum
{
    public enum LogType
    {
        Login,
        View,
        Like,
        Error,
        CommentReport,
        ClipReport,
        UserUpdate,
        MessageUpdate,
        MessageReport,
        Referral,
        PasswordReset,
        CommentDelete,
        GameFollowed,
        GameUnfollowed,
        ClipShared
    }
}
