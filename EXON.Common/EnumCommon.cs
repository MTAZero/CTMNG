using System;

namespace EXON.Common
{
    [Flags]
    public enum IsQuizEnum { Quiz, Essay };

    public enum QuestionFormat { Html, RTF };

    public enum QuestionStatus { New, Accepted, Repair }

    public enum ContestStatus { New, Accepted, Cancel, Done, DuringNotShit, DuringNotTest, DuringHaveTest, DuringConTest }

    public enum LoginStatus { Login, Logout, Close, None }

    public enum OriginalTestStatus { New, Accepted, Repair }

    public enum PositionEnum { NEW, ADMIN, TPKT, TLKT, TK, CNBM, GV, CBTN }

    public enum TaskStatusEnum { New, During, Over, Complete }

    public enum Register { Deleted, New, Receipted, Iscontestant }

    public enum ProcessStatus { New, OK, Cancel, Break }

    public enum TypeServer { Main, Local}
}