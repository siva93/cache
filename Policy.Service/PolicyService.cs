namespace Policy.Service.Interface
{
    using System;
    using Policy.Service.Entity;
    using CacheProvider.Interface;
    using Microsoft.Extensions.Logging;
    public class PolicyService : IPolicyService
    {
        private readonly ICacheProvider _cacheProvider;
        private readonly ILogger<PolicyService> _logger;
        public PolicyService(ICacheProvider cacheProvider, ILogger<PolicyService> logger)
        {
            _logger = logger;
            _cacheProvider = cacheProvider;
        }
        public PolicyDetail GetPolicyDetail(string policyNumber)
        {
            _logger.LogInformation(policyNumber);
            var cache = _cacheProvider.Get<PolicyDetail>(policyNumber);
            if (cache != null)
            {
                return cache;
            }
            else
            {
                //The value will be fetched from core service
                var policy = new PolicyDetail()
                {
                    PolicyNumber = policyNumber,
                    PolicyId = Guid.NewGuid().ToString(),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(2)
                };

                //Add the response into the cache
                _cacheProvider.Set(policyNumber, policy);
                return policy;
            }
        }
    }
}