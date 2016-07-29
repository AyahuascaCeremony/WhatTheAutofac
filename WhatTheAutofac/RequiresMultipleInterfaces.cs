namespace WhatTheAutofac
{
    class RequiresMultipleInterfaces : IRequireMultipleInterfaces
    {
        public RequiresMultipleInterfaces(IFirstInterface firstInstance, ISecondInterface secondInstance)
        {
            
        }
        public RequiresMultipleInterfaces(IFirstInterface firstInstance)
        {
            
        }
    }
}