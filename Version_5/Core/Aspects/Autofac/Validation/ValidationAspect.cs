﻿using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//Reflection.. Product Validator ün intstancesini oluşturur
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];  //ProductValitadorun Base tipini bul yani AbstractValidator<Product>
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //İlgili metodun metodun paremetrelerine bak.
            foreach (var entity in entities) //paremetrelerin her birini tek tek gez.
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
