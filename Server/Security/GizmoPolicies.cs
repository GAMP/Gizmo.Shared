namespace Gizmo.Server
{
    /// <summary>
    /// Gizmo permissions.
    /// </summary>
    /// <remarks>
    /// Defines permissions/policies supported by application.
    /// </remarks>
    public enum GizmoPolicies
    {
        #region SALE
        /// <summary>
        /// Sale permission.
        /// </summary>
        [PolicyDescription(@"Sale", "*", "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE")]
        Sale,

        /// <summary>
        /// Sale at custom permission.
        /// </summary>
        [PolicyDescription(@"Sale", "CustomPrice", new GizmoPolicies[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_CUSTOM_PRICE")]
        SaleCustomPrice,

        /// <summary>
        /// Sale with non default vat permission.
        /// </summary>
        [PolicyDescription(@"Sale", "NonDefaultVat", new GizmoPolicies[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_NON_DEFAULT_VAT", IsAssignable = false)]
        SaleNonDefaultVat,

        /// <summary>
        /// Sale with pay later permission.
        /// </summary>
        [PolicyDescription(@"Sale", "PayLater", new GizmoPolicies[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_PAY_LATER")]
        SaleNonPayLater,

        /// <summary>
        /// Sale void invoice permission.
        /// </summary>
        [PolicyDescription(@"Sale", "VoidInvoices", new GizmoPolicies[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VOID_INVOICES")]
        SaleNoVoidInvoices,

        /// <summary>
        /// Void used time invoices permission.
        /// </summary>
        [PolicyDescription(@"Sale", "VoidUsedTimeInvoices", new GizmoPolicies[] { SaleNoVoidInvoices }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VOID_USED_TIME_INVOICES")]
        VoidUsedTimeInvoices,

        /// <summary>
        /// Void closed shift invoices permission.
        /// </summary>
        [PolicyDescription(@"Sale", "VoidClosedShiftInvoices", new GizmoPolicies[] { SaleNoVoidInvoices }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VOID_CLOSED_SHIFT_INVOICES")]
        VoidClosedShiftInvoices,

        /// <summary>
        /// Void other operator invoices permission.
        /// </summary>
        [PolicyDescription(@"Sale", "VoidOtherOperatorInvoices", new GizmoPolicies[] { SaleNoVoidInvoices }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VOID_OTHER_OPERATOR_INVOICES")]
        VoidOtherOperatorInvoices,

        /// <summary>
        /// Void previous business day invoices permission.
        /// </summary>
        [PolicyDescription(@"Sale", "VoidPastDaysInvoices", new GizmoPolicies[] { SaleNoVoidInvoices }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VOID_PAST_DAYS_INVOICES")]
        VoidPastDaysInvoices,

        /// <summary>
        /// Sale deposit permission.
        /// </summary>
        [PolicyDescription(@"Sale", "Deposit", new GizmoPolicies[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_DEPOSIT")]
        Deposit,

        /// <summary>
        /// Sale withdraw permission.
        /// </summary>
        [PolicyDescription(@"Sale", "Withdraw", new GizmoPolicies[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_WITHDRAW")]
        Withdraw,

        /// <summary>
        /// Sale void deposits permission.
        /// </summary>
        [PolicyDescription(@"Sale", "VoidDeposits", new GizmoPolicies[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VOID_DEPOSITS")]
        VoidDeposits,

        /// <summary>
        /// Sale manual open cash drawer permission.
        /// </summary>
        [PolicyDescription(@"Sale", "ManualOpenCashDrawer", new GizmoPolicies[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_MANUAL_OPEN_CASH_DRAWER")]
        SaleManualOpenCashDrawer,

        /// <summary>
        /// Sale modify billing options permission.
        /// </summary>
        [PolicyDescription(@"Sale", "ModifyBillingOptions", new GizmoPolicies[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_MODIFY_BILLING_OPTIONS")]
        SaleModifyBillingOptions,

        /// <summary>
        /// Sale allow time credit permission.
        /// </summary>
        [PolicyDescription(@"Sale", "AllowTimeCredit", new GizmoPolicies[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_ALLOW_TIME_CREDIT")]
        AllowTimeCredit,

        /// <summary>
        /// Sale disable receipt print permission.
        /// </summary>
        [PolicyDescription(@"Sale", "AllowDisableReceiptPrint", new GizmoPolicies[] { Sale }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_ALLOW_DISABLE_RECEIPT_PRINT")]
        SaleAllowDisableReceiptPrint,

        /// <summary>
        /// View invoices permission.
        /// </summary>
        [PolicyDescription(@"Sale", "ViewInvoices", "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VIEW_INVOICES")]
        ViewInvoices,

        /// <summary>
        /// View only unpaid invoices permission.
        /// </summary>
        [PolicyDescription(@"Sale", "ViewPaidInvoices", new GizmoPolicies[] { ViewInvoices }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VIEW_PAID_INVOICES")]
        ViewPaidInvoices,

        /// <summary>
        /// View only business day invoices permission.
        /// </summary>
        [PolicyDescription(@"Sale", "ViewPastDaysInvoices", new GizmoPolicies[] { ViewInvoices }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VIEW_PAST_DAYS_INVOICES")]
        ViewPastDaysInvoices,

        /// <summary>
        /// View deposits permission.
        /// </summary>
        [PolicyDescription(@"Sale", "ViewDeposits", "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VIEW_DEPOSITS")]
        ViewDeposits,

        /// <summary>
        /// View only business day deposits permission.
        /// </summary>
        [PolicyDescription(@"Sale", "ViewPastDaysDeposits", new GizmoPolicies[] { ViewDeposits }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VIEW_PAST_DAYS_DEPOSITS")]
        ViewPastDaysDeposits,

        /// <summary>
        /// View register transactions permission.
        /// </summary>
        [PolicyDescription(@"Sale", "ViewRegisterTransactions", "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VIEW_REGISTER_TRANSACTIONS")]
        ViewRegisterTransactions,

        /// <summary>
        /// View only business day register transactions permission.
        /// </summary>
        [PolicyDescription(@"Sale", "ViewPastDaysRegisterTransactions", new GizmoPolicies[] { ViewRegisterTransactions }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_SALE_VIEW_PAST_DAYS_REGISTER_TRANSACTIONS")]
        ViewPastDaysRegisterTransactions,

        /// <summary>
        /// Sale delete time purchases permission.
        /// </summary>
        [PolicyDescription(@"Sale", "DeleteTimePurchases", "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_DELETE_TIME_PURCHASES")]
        SaleNoDeleteTimePurchases,

        #endregion

        #region SHIFT
        /// <summary>
        /// Shift view expected permission.
        /// </summary>
        [PolicyDescription(@"Shift", "ViewExpected", "PERMISSION_GROUP_SHIFT", "PERMISSION_ACTION_SHIFT_VIEW_EXPECTED")]
        ShiftCountViewExpected,
        #endregion

        #region STOCK

        /// <summary>
        /// Stock permission.
        /// </summary>
        [PolicyDescription(@"Stock", "*", "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_STOCK_ACCESS")]
        StockAccess,

        /// <summary>
        /// Stock permission.
        /// </summary>
        [PolicyDescription(@"Stock", "Manage", new GizmoPolicies[] { StockAccess }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_STOCK_MANAGE")]
        StockManage,

        /// <summary>
        /// Stock permission.
        /// </summary>
        [PolicyDescription(@"Stock", "ViewStockTransactions", "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_STOCK_VIEW_STOCK_TRANSACTIONS")]
        ViewStockTransactions,

        /// <summary>
        /// Stock permission.
        /// </summary>
        [PolicyDescription(@"Stock", "ViewPastDaysStockTransactions", new GizmoPolicies[] { ViewStockTransactions }, "PERMISSION_GROUP_SALE", "PERMISSION_ACTION_STOCK_VIEW_PAST_DAYS_STOCK_TRANSACTIONS")]
        ViewPastDaysStockTransactions,

        #endregion

        #region MANAGEMENT

        /// <summary>
        /// Management permission.
        /// </summary>
        [PolicyDescription(@"Management", "*", "PERMISSION_GROUP_MANAGEMENT", "PERMISSION_ACTION_MANAGEMENT")]
        Management,

        /// <summary>
        /// Management access tasks permission.
        /// </summary>
        [PolicyDescription(@"Management", "Tasks", new GizmoPolicies[] { Management }, "PERMISSION_GROUP_MANAGEMENT", "PERMISSION_ACTION_MANAGEMENT_TASKS")]
        ManagementTasks,

        /// <summary>
        /// Management access processes permission.
        /// </summary>
        [PolicyDescription(@"Management", "Processes", new GizmoPolicies[] { Management }, "PERMISSION_GROUP_MANAGEMENT", "PERMISSION_ACTION_MANAGEMENT_PROCESSES")]
        ManageProcesses,

        /// <summary>
        /// Management access files permission.
        /// </summary>
        [PolicyDescription(@"Management", "Files", new GizmoPolicies[] { Management }, "PERMISSION_GROUP_MANAGEMENT", "PERMISSION_ACTION_MANAGEMENT_FILES")]
        ManageFiles,

        /// <summary>
        /// Management maintenance mode permission.
        /// </summary>
        [PolicyDescription(@"Management", "Maintenance", "PERMISSION_GROUP_MANAGEMENT", "PERMISSION_ACTION_MANAGEMENT_MAINTENANCE")]
        ManageMaintenance,

        /// <summary>
        /// Management security permission.
        /// </summary>
        [PolicyDescription(@"Management", "Security", "PERMISSION_GROUP_MANAGEMENT", "PERMISSION_ACTION_MANAGEMENT_SECURITY")]
        ManageSecurity,

        /// <summary>
        /// Management lock state permission.
        /// </summary>
        [PolicyDescription(@"Management", "LockState", "PERMISSION_GROUP_MANAGEMENT", "PERMISSION_ACTION_MANAGEMENT_LOCK_STATE")]
        ManageLockState,

        /// <summary>
        /// Management module restart permission.
        /// </summary>
        [PolicyDescription(@"Management", "ModuleRestart", "PERMISSION_GROUP_MANAGEMENT", "PERMISSION_ACTION_MANAGEMENT_MODULE_RESTART")]
        ManageModuleRestart,

        /// <summary>
        /// Management power on endpoints permission.
        /// </summary>
        [PolicyDescription(@"Management", "PowerOnEndpoints", "PERMISSION_GROUP_MANAGEMENT", "PERMISSION_ACTION_MANAGEMENT_POWER_ON_ENDPOINTS")]
        ManagePowerOnEndpoints,

        #endregion

        /// <summary>
        /// Deployment permission.
        /// </summary>
        [PolicyDescription(@"Deployment", "*", "PERMISSION_GROUP_DEPLOYMENT", "PERMISSION_ACTION_DEPLOYMENT")]
        Deployment,

        /// <summary>
        /// Monitoring permission.
        /// </summary>
        [PolicyDescription(@"Monitoring", "*", "PERMISSION_GROUP_MONITORING", "PERMISSION_ACTION_MONITORING")]
        Monitoring,

        /// <summary>
        /// Reports permission.
        /// </summary>
        [PolicyDescription(@"Reports", "*", "PERMISSION_GROUP_REPORTS", "PERMISSION_ACTION_REPORTS")]
        Reports,

        /// <summary>
        /// Server settings permission.
        /// </summary>
        [PolicyDescription(@"Settings", "*", "PERMISSION_GROUP_MAIN", "PERMISSION_ACTION_SERVER_SETTINGS")]
        ServerSettings,

        /// <summary>
        /// Applications permission.
        /// </summary>
        [PolicyDescription(@"Apps", "*", "PERMISSION_GROUP_APPLICATIONS", "PERMISSION_ACTION_APPLICATIONS")]
        Applications,

        /// <summary>
        /// News permission.
        /// </summary>
        [PolicyDescription(@"News", "*", "PERMISSION_GROUP_NEWS", "PERMISSION_ACTION_NEWS")]
        News,

        #region USER

        /// <summary>
        /// Reset user password permission.
        /// </summary>
        [PolicyDescription(@"User", "UserPasswordReset", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_PASSWORD_RESET")]
        UserResetPassword,

        /// <summary>
        /// Enable user permission.
        /// </summary>
        [PolicyDescription(@"User", "UserEnable", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_ENABLE")]
        UserEnable,

        /// <summary>
        /// Disable user permission.
        /// </summary>
        [PolicyDescription(@"User", "UserDisable", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_DISABLE")]
        UserDisable,

        /// <summary>
        /// Manual user login permission.
        /// </summary>
        [PolicyDescription(@"User", "UserManualLogin", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_MANUAL_LOGIN")]
        UserManualLogin,

        /// <summary>
        /// Add user permission.
        /// </summary>
        [PolicyDescription(@"User", "Add", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_ADD")]
        UserAdd,

        /// <summary>
        /// Delete user permission.
        /// </summary>
        [PolicyDescription(@"User", "Delete", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_DELETE")]
        UserDelete,

        /// <summary>
        /// Change user name permission.
        /// </summary>
        [PolicyDescription(@"User", "ChangeUserName", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_CHANGE_USERNAME")]
        UserChangeUserName,

        /// <summary>
        /// Change user group permission.
        /// </summary>
        [PolicyDescription(@"User", "ChangeUserGroup", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_CHANGE_USERGROUP")]
        UserChangeUserGroup,

        /// <summary>
        /// Edit user permission.
        /// </summary>
        [PolicyDescription(@"User", "Edit", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_EDIT")]
        UserEdit,

        /// <summary>
        /// Edit user permission.
        /// </summary>
        [PolicyDescription(@"User", "AccessStats", "PERMISSION_GROUP_USER", "PERMISSION_ACTION_USER_ACCESS_STATS")]
        UserAccessStats,

        #endregion

        #region LOG

        /// <summary>
        /// Access log permission.
        /// </summary>
        [PolicyDescription(@"Log", "*", "PERMISSION_GROUP_LOG", "PERMISSION_ACTION_LOG_ACCESS")]
        LogAccess,

        /// <summary>
        /// Clear log permission.
        /// </summary>
        [PolicyDescription(@"Log", "Clear", new GizmoPolicies[] { LogAccess }, "PERMISSION_GROUP_LOG", "PERMISSION_ACTION_LOG_CLEAR")]
        LogClear,

        #endregion

        #region WAITING_LINES

        /// <summary>
        /// Access waiting lines permission.
        /// </summary>
        [PolicyDescription(@"WaitingLines", "*", "PERMISSION_GROUP_WAITING_LINES", "PERMISSION_ACTION_WAITING_LINES_ACCESS")]
        WaitingLinesAccess,

        /// <summary>
        /// Manage waiting lines permission.
        /// </summary>
        [PolicyDescription(@"WaitingLines", "Manage", new GizmoPolicies[] { WaitingLinesAccess }, "PERMISSION_GROUP_WAITING_LINES", "PERMISSION_ACTION_WAITING_LINES_MANAGE")]
        WaitingLinesManage,

        #endregion

        #region REGISTER_TRANSACTIONS

        /// <summary>
        /// Create pay in register transactions permission.
        /// </summary>
        [PolicyDescription(@"RegisterTransactions", "RegisterTransactionsPayIn", "PERMISSION_GROUP_REGISTER_TRANSACTIONS", "PERMISSION_REGISTER_TRANSACTIONS_PAY_IN")]
        RegisterTransactionsPayIn,

        /// <summary>
        /// Create pay out register transactions permission.
        /// </summary>
        [PolicyDescription(@"RegisterTransactions", "RegisterTransactionsPayOut", "PERMISSION_GROUP_REGISTER_TRANSACTIONS", "PERMISSION_REGISTER_TRANSACTIONS_PAY_OUT")]
        RegisterTransactionsPayOut,

        #endregion

        #region WEB API
        [PolicyDescription(@"WebApi", "*", "PERMISSION_GROUP_WEB_API", "PERMISSION_ACTION_WEB_API")]
        WebApi,
        #endregion
    }
}
