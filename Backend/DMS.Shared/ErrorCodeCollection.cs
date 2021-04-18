using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Shared
{
    public static class ErrorCodeCollection
    {
        public static class AccountError
        {
            public const string AccountCreateFailed = "Account-Created-Failed";
            public const string AccountUpdateFailed = "Account-Update-Failed";
            public const string AccountDelteleFailed = "Account-Deltele-Failed";
            public const string AccoutLoginedFailed = "Account-Logined-Failed";
            public const string AccoutWrittenLogFailed = "Account-WrittenLog-Failed";
            public const string TokenInvalid = "Token-Invalid";
            public const string YouDoNotHavePermission = "Token-Invalid-Or-You-Do-Not-Have-Permission-In-This-Area";
            public const string AccountInvalid = "Account-Invalid";
            public const string AccountAlreadyExists = "Account-Already-Exists";
            public const string AccountPasswordInvalid = "Account-Password-Invalid";
            public const string OrganizationDisable = "Organization-Disable";
            public const string AccountStatusIsDisable = "Account-Status-Is-Disable";
            public const string UsernameIsExist = "Username-Is-Exist";
            public const string OldPassWordNotCorrect = "Old-Password-Is-Not-Correct";
            public const string PassWordIsNull = "Password-Is-Null";
            public const string DoNotNeedToCheck = "do-not-need-to-check";
        }
        public static class MyDrive
        {
            public const string MyDriveInsertFail = "MyDrive-Insert-Failed";
            public const string MyDriveUpdateFail = "MyDrive-Update-Failed";
            public const string MyDriveDeleteFail = "MyDrive-Delete-Failed";

        }
        public static class InvalidProfile
        {
            public const string InvalidProfileInsertFail = "InvalidProfile-Insert-Failed";
            public const string InvalidProfileUpdateFail = "InvalidProfile-Update-Failed";
            public const string InvalidProfileDeleteFail = "InvalidProfile-Delete-Failed";
        }
        public static class MyFile
        {
            public const string MyFileInsertFail = "MyFile-Insert-Failed";
            public const string MyFileUpdateFail = "MyFile-Update-Failed";
            public const string MyFileDeleteFail = "MyFile-Delete-Failed";
            public const string MyFileDeleteAllByMyDriveIdFail = "MyFile-DeleteAll-By-MyDriveId-Failed";
        }

        public static class ProfileError
        {
            public const string FrofileCreateFailed = "Profile-Created-Failed";
            public const string ProfileUpdateFailed = "Profile-Update-Failed";
            public const string ProfileDeleteFailed = "Profile-Delete-Failed";

            public const string NameNotValid = "Name-Not-Valid";
            public const string StoreNotValid = "Store-Not-Valid";
            public const string StatusNotValid = "Status-Not-Valid";
            public const string StatusIsEnable = "Status-Is-Enable";
            public const string ProfileExits = "Profile-Has-Exits";
            public const string LengthLimit = "Length-exceeds-the-allowed-limit";
        }

        public static class ProfileTemplateError
        {
            public const string ProfileTemplateUpsertFailed = "Profile-Template-Upsert-Failed";
            public const string ProfileTemplateDeleteFailed = "Profile-Template-Delete-Failed";
        }

        public static class DocumentError
        {
            public const string DocumentCreateFailed = "Document-Created-Failed";
            public const string DocumentUpdateFailed = "Document-Update-Failed";
            public const string DocumentDeleteFailed = "Document-Delete-Failed";
        }

        public static class DocumentTemplateError
        {
            public const string DocumentTemplateUpsertFailed = "Document-Template-Upsert-Failed";
            public const string DocumentTemplateDeleteFailed = "Document-Template-Delete-Failed";
        }

        public static class Attachment
        {
            public const string AttachmentCreateFailed = "Attachment-Created-Failed";
            public const string AttachmentUpdateFailed = "Attachment-Update-Failed";
            public const string AttachmentDeleteFailed = "Attachment-Delete-Failed";
            public const string SignAccountIsNotValid = "Sign-Account-Is-Not-Valid";
            public const string SignAccountConfigureOTP = "Sign-Account-Configure-OTP";
            public const string FileStyleIsNotValid = "File-Style-Is-Not-Valid";
        }

        public static class Category
        {
            public const string CategoryCreateFailed = "Category-Created-Failed";
            public const string CategoryUpdateFailed = "Category-Update-Failed";
            public const string CategoryDeleteFailed = "Category-Delete-Failed";
            public const string CategoryExistProfile = "Category-Exist-Profile";
            public const string CategoryTemplateDeleteFailed = "Category-Template-Delete-Failed";
        }

        public static class Store
        {
            public const string StoreCreateFailed = "Store-Created-Failed";
            public const string StoreUpdateFailed = "Store-Updated-Failed";
            public const string StoreDeleteFailed = "Store-Deleted-Failed";
            public const string ChildStoreCreateFailed = "Child-Store-Created-Failed";
            public const string StoreCountChildFailed = "CountChild-Store-Failed";
            public const string StoreExistChildFailed = "ExistChild-Store-Failed";
        }

        public static class Organization
        {
            public const string OrganizationNotFound = "Organization-Not-Found";
            public const string OrganizationCreateFailed = "Workspace-Created-Failed";
            public const string OrganizationUpdateFailed = "Workspace-Updated-Failed";
            public const string OrganizationDeleteFailed = "Workspace-Deleted-Failed";
            public const string OrganizationCheckDeleteFailed = "Organization-Check-Delete-Failed";
            public const string OrganizationAlreadyExists = "Organization-Already-Exists";
            public const string CodeAlreadyExist = "Code-Already-Exist";
        }
        public static class Workspace
        {
            public const string WorkspaceCreateFailed = "Workspace-Created-Failed";
            public const string WorkspaceUpdateFailed = "Workspace-Updated-Failed";
            public const string WorkspaceDeleteFailed = "Workspace-Deleted-Failed";
        }
        public static class Search
        {
            public const string SearchCreateFailed = "Data-Search-Created-Failed";
            public const string SearchUpdateFailed = "Data-Search-Updated-Failed";
            public const string SearchDeleteFailed = "Data-Search-Deleted-Failed";
            public const string SearchNotFound = "Data-Search-Not-Found";
        }

        public static class Valid
        {
            public const string DataResultIsNull = "Data-Result-Is-Null";
            public const string CreateCodeFailed = "Create-Code-Failed";
            public const string NotFoundKeyVirtual = "Not found key id. You can login system again.";
        }

        public static class Lock
        {
            public const string LockObjectFailed = "Couchbase.TemporaryLockFailureException: A temporary lock error was detected for key";
        }

        public static class Permission
        {

            public const string DataResultNotFound = "Data-Result-Not-Found";
            public const string YouDontHavePermissonInThisArea = "You-Dont-Have-Permission-In-This-Area";
            public const string YouDontHaveEnoughPermission = "You-Dont-Have-Enough-Permision";
            public const string SessionDecentralizationTimeout = "Session-Decentralization-Timeout";
            public const string ListProfileMustBeInTheSameOrganizationAndDecentralization = "List-Profile-Must-Be-In-The-Same-Organization-And-Decentralization";
        }

        public static class MenuItem
        {
            public const string MenuItemCreateFailed = "MenuItem-Created-Failed";
            public const string MenuItemUpdateFailed = "MenuItem-Update-Failed";
            public const string MenuItemDeleteFailed = "MenuItem-Delete-Failed";
            public const string MenuItemCodeInvalid = "MenuItem-Code-Invalid";
        }

        public static class command
        {
            public const string commandCreateFailed = "command-Created-Failed";
            public const string commandUpdateFailed = "command-Update-Failed";
            public const string commandDeleteFailed = "command-Delete-Failed";
        }

        public static class Role
        {
            public const string RoleCreateFailed = "Role-Created-Failed";
            public const string RoleUpdateFailed = "Role-Update-Failed";
            public const string RoleDeleteFailed = "Role-Delete-Failed";
        }
        public static class Policy
        {
            public const string PolicyCreateFailed = "Policy-Created-Failed";
            public const string PolicyUpdateFailed = "Policy-Update-Failed";
            public const string PolicyDeleteFailed = "Policy-Delete-Failed";
            public const string CodeAlreadyExist = "Code-Already-Exist";
        }

        public static class Department
        {
            public const string DepartmentCreateFailed = "Department-Created-Failed";
            public const string DepartmentUpdateFailed = "Department-Update-Failed";
            public const string DepartmentDeleteFailed = "Department-Delete-Failed";
            public const string DepartmentCodeInvalid = "Department-Code-Invalid";
            public const string DepartmentExistChild = "Department-Exist-Child";
            public const string CodeAlreadyExist = "Code-Already-Exist";
        }

        public static class Parameter
        {
            public const string ParameterCreateFailed = "Parameter-Created-Failed";
            public const string ParameterUpdateFailed = "Parameter-Update-Failed";
            public const string ParameterDeleteFailed = "Parameter-Delete-Failed";
            public const string ParameterSyncFailed = "Parameter-Sync-Failed";
            public const string ParameterExistCode = "Parameter-Exist-Code";
        }
        public static class RegistrationForm
        {
            public const string RegistrationFormNotFound = "RegistrationForm-Not-Found";
            
            public const string RegistrationFormIsNotCreate = "RegistrationForm-Is-Not-Create";
            public const string RegistrationFormIsNotEnable = "RegistrationForm-Is-Not-Enable";

            public const string RegistrationFormCreatedFailed = "RegistrationForm-Created-Failed";
            public const string RegistrationFormUpdatedFailed = "RegistrationForm-Updated-Failed";
            public const string RegistrationFormDeletedFailed = "RegistrationForm-Deleted-Failed";

        }

        public static class BorrowProfile
        {
            public const string BorrowProfileInvalid = "BorrowProfile-Invalid";
        }

        public static class Dictionary 
        {
            public const string IdDefinitionIsNotExist = "Id-Definition-Is-Not-Exist";
            public const string DictionaryCodeIsExist = "Dictionary-Code-Is-Exist";
            public const string DictionaryCreateFail = "Dictionary-Create-Fail";
        }
        public static class DictionaryDefinition
        {
            public const string IdDefinitionIsNotExist = "Id-Definition-Is-Not-Exist";
            public const string DictionaryCodeIsExist = "Dictionary-Code-Is-Exist";
            public const string DictionaryDefinitionCreateFail = "Dictionary-Definition-Create-Fail";
            public const string CodeAlreadyExist = "Code-Already-Exist";
        }
        public static class ProfileLog
        {
            public const string AccountIsNotValid = "Account-Is-Not-Valid";
            public const string DeleteLog = "Delete-Log-Falled";
        }
        public static class Comment
        {
            public const string CommentCreateFail = "Comment-Create-Fail";
            public const string CommentUpdateFail = "Comment-Update-Fail";
            public const string CommentDeleteFail = "Comment-Delete-Fail";
        }
        public static class ReportDefinition
        {
            public const string ReportDefinitionCreateFail = "ReportDefinition-Create_Fail";
            public const string ReportDefinitionUpdateFail = "ReportDefinition-Update_Fail";
            public const string ReportDefinitonDeleteFail = "ReportDefinition-Delete-Fail";
            public const string FileIsExist = "File-Is-Exist";
        }
        public static class DanhMucTinhThanhPho
        {
            public const string DanhMucTinhThanhPhoCreateFail = "DanhMucTinhThanhPho-Create-Fail";
            public const string DahMucTinhThanhPhoUpdateFail = "DanhMucTinhThanhPho-Update-Fail";
            public const string DanhMucTinhThanhPhoDeleteFail = "DanhMucTinhThanhPho-Delete-Fail";
        }
        public static class Notification
        {
            public const string NotificationCreateFail = "Notification-Create-Fail";
            public const string NotificationUpdateFail = "Notification-Updata-Fail";
            public const string NotificationDeleteFail = "Notification-Delete-Fail";
        }
        public static class LoaiVanBan
        {
            public const string LoaiVanBanCreateFail = "LoaiVanBan-Create-Fail";
            public const string LoaiVanBanUpdateFail = "LoaiVanBan-Update-Fail";
            public const string LoaiVanBanDeleteFail = "LoaiVanBan-Delete-Fail";
            public const string CodeAlreadyExist = "Code-Already-Exist";
        }
        public static class ReportQuery
        {
            public const string ReportQueryCreateFail = "ReportQuery-Create-Fail";
            public const string ReportQueryUpdateFail = "ReportQuery-Update-Fail";
            public const string ReportQueryDeleteFail = "ReportQuery-Delete-Fail";
        }
    }
}
