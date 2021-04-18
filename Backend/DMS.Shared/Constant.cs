using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Shared
{
    public static class Constant
    {
        public static class Account
        {
            public const string UserSystemAdmin = "SystemAdmin";
            public const int StatusMenuSystemAdmin = 10;
            public const int StatusDisable = 0;
        }
        public static class Organization
        {
            public const string NotChangePermission = "Not-Change-Permission";
            public const int StatusMenuSystemAdmin = 10;
            public const int StatusDisable = 0;
        }

        public static class LevelStore
        {
            public const int WarehouseLevel = 10;
            public const int RackLevel = 20;
            public const int ShelfLevel = 30;
            public const int BoxLevel = 40;
        }
        public static class ProfileStatus
        {
            public const int ProfileWaiting = 0;
            public const int ProfileEnable = 1;
            public const int ProfileDisable = 2;
        }

        public static class ObjectStatus
        {
            public const int ObjectEnable = 1;
            public const int ObjectDisable = 2;
            public const string ObjectInserChild = "INSERTCHILD";
            public const string ObjectUpdate = "UPDATE";
            public const string ObjectDelete = "DELETE";
        }

        public static class PrefixCode
        {
            public const string PrefixProfile = "HS";
            public const string PrefixBorrowProfile = "MUONHS";
            public const string PrefixDocument = "TM";
            public const string PrefixWarehouse = "KHO";
            public const string PrefixRack = "KE";
            public const string PrefixShelf = "TANG";
            public const string PrefixBox = "HOP";
            public const string PrefixNameProfileForImport = "Hồ sơ có mã ";
            public const string PrefixCategory = "MAU";
            public const string SuffixProfile = "000000";
            public const string SuffixProfileLog = "000000";
            public const string SuffixDocument = "000000";
            public const string SuffixStore = "000000";
            public const string SuffixCategory = "000000";
            public const string SuffixBorrowProfile = "00000000";
        }

        public static class TimeLock
        {
            public const int TimeLockDocument = 5000;
            public const int TimeRepeat = 500;
        }

        public static class TimeExpired
        {
            public const int TimeExpiredToken = 43000;      //with minute 
        }

        public static class RoleCode
        {
            public const string RoleCodeSystemAdmin = "SYSTEMADMIN";
            public const string RoleCodeOganization = "OGANIZATION";
        }

        public static class PolicyCode
        {
            public const string PolicyGroupAdminLocal = "GROUPADMINLOCAL";
            public const string PolicyCodeMenu = "MENU";
            public const string PolicyGroupMenu = "GROUP";
            public const string Policygeneralgroup = "GENGROUP";
            public const string Policyapprovalgroup = "APPROVALGROUP";
            public const string Policyapprovalgroup1 = "APPROVALGROUP1";
            public const string Policyapprovalgroup2 = "APPROVALGROUP2";
            public const string PolicyGroupReport = "GROUPREPORT";
            public const string PolicyCodeReport = "MENUREPORT";
        }

        public static class StatementCode
        {
            public const string StatementCodeMenu = "STATEMENTMENU";
            public const string StatementCodeStore = "STATEMENTSTORE";
            public const string StatementCodeCategory = "STATEMENTCATEGORY";
            public const string StatementCodeIsImportProfile = "STATEMENTISIMPORTPROFILE";
            public const string StatementCodeAccount = "STATEMENTACCOUNT";
            public const string StatementCodeReport = "STATEMENTREPORT";

        }

        public static class Group
        {
            public const string ApprovalGroup1Name = "Nhóm duyệt khi đăng ký mượn";
            public const string ApprovalGroup2Name = "Nhóm duyệt khi chuyển cấp";
        }
        public static class Permission
        {
            public const string FlagUpdateTree = "true";
            public const string FlagNopeUpdateTree = "false";
        }
        public static class Parameter
        {
            public const int ParameterIsEdit = 1;
            public const int ParameterDisableEdit = 0;
        }

        public static class Search
        {
            public const int ProfileStatusEnable = 1;
            public const int ProfileStatusDisable = 0;
            public const int ProfileNopeStatus = -1;
            public const int ProfilePublic = 7;
        }

        public static class Borrow
        {
            public const int BorrowStatusGetAll = -100;
            public const int BorrowStatusEnable = -1;
            public const int BorrowStatusCreate = 0;
            
            public const int BorrowStatusRenew = 2;
            public const int BorrowStatusCancel = 10;
            //public const int BorrowStatusApprovedLevel1 = 3;
            public const int BorrowStatusApprovalEnable = -1;
            //public const int BorrowStatusApprovalCancel = 1;
            //public const int BorrowStatusApprovalRecalled = 0;
            public const int BorrowStatusApprovalReniew = 2;
            public const int BorrowStatusApprovalMove = 3;
            //public const int BorrowStatusUserEditInfomation = 4;
            public const int BorrowStatusApprovalCancel = -10;
            public const int BorrowAccountWithValidBorrow = -30;
            public const int BorrowAccountWithInvalidBorrow = 30;
        }

        public static class BorrowActive
        {
            //public const int BorrowStatusGetAll = -100;
            //public const int BorrowStatusEnable = -1;
            //public const int BorrowStatusCreate = 0;
            public const int ActiveEditFormByBorrowAccount = 1001;
            public const int BorrowStatusRenew = 2;
            public const int BorrowStatusCancel = 10;
            public const int BorrowStatusCreate = 0;
            public const int BorrowStatusSetEnable =-1;
            ////public const int BorrowStatusApprovedLevel1 = 3;
            //public const int BorrowStatusApprovalEnable = -1;
            ////public const int BorrowStatusApprovalCancel = 1;
            ////public const int BorrowStatusApprovalRecalled = 0;
            //public const int BorrowStatusApprovalReniew = 2;
            //public const int BorrowStatusApprovalMove = 3;
            //public const int BorrowStatusUserEditInfomation = 4;
            //public const int BorrowStatusApprovalCancel = -10;
            //public const int BorrowAccountWithValidBorrow = -30;
            //public const int BorrowAccountWithInvalidBorrow = 30;
        }

        public static class Category
        {
            public const int Borrow = 1;
            public const int NotBorrow = 0;
        }

        public static class Details
        {
            public const string DateTimeMinValueDetail = "01010001";
        }

    }
}
