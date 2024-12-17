using System.ComponentModel.DataAnnotations;

namespace Gizmo.Server.Security
{
    /// <summary>
    /// Gizmo policy set.
    /// </summary>
    public enum GizmoPolicySet
    {
        [Name("Cashier","GIZMO_POLICY_SET_CASHIER_NAME")]
        [ExtendedDescription("Cashier user", "GIZMO_POLICY_SET_CASHIER_DESCRIPTION")]
        Cashier,
      
        [Name("Manager", "GIZMO_POLICY_SET_MANAGER_NAME")]
        [ExtendedDescription("Manager user", "GIZMO_POLICY_SET_MANAGER_DESCRIPTION")]
        Manager,
      
        [Name("Technician", "GIZMO_POLICY_SET_TECHNICIAN_NAME")]
        [ExtendedDescription("Technician user", "GIZMO_POLICY_SET_TECHNICIAN_DESCRIPTION")]
        Technician,
        
        [Name("Marketer", "GIZMO_POLICY_SET_MARKETER_NAME")]
        [ExtendedDescription("Marketer user", "GIZMO_POLICY_SET_MARKETER_DESCRIPTION")]
        Marketer,
        
        [Name("Owner", "GIZMO_POLICY_SET_OWNER_NAME")]
        [ExtendedDescription("Owner user", "GIZMO_POLICY_SET_OWNER_DESCRIPTION")]
        Owner,
    }
}
