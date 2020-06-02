namespace Policy.Service.Interface
{
    using Policy.Service.Entity;
    public interface IPolicyService
    {
        PolicyDetail GetPolicyDetail(string policyNumber);

    }
}