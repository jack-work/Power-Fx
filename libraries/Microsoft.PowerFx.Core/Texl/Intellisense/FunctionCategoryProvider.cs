﻿//------------------------------------------------------------------------------
// <copyright file="StringResources.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.PowerFx.Core.Localization;
using Microsoft.PowerFx.Core.Types;

namespace Microsoft.PowerFx.Core.Texl.Intellisense
{
    public sealed class FunctionCategoryProvider
    {
        /// <summary>
        /// Returns a list of all the function categories in the document.
        /// The enumerated function categories are locale-specific.
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> GetFunctionCategories()
        {
            foreach (var category in Enum.GetValues(typeof(FunctionCategories)))
            {
                if (category.Equals(FunctionCategories.None))
                    continue;

                var str = StringResources.Get("FunctionCategoryName_" + category.ToString());
                yield return new KeyValuePair<string, string>(category.ToString(), str);
            }
        }

        /// <summary>
        /// Returns a list of all the function categories in the document.
        /// The enumerated function categories are locale-specific.
        /// </summary>
        public Task<IEnumerable<KeyValuePair<string, string>>> GetFunctionCategoriesAsync()
        {
            return Task.FromResult(GetFunctionCategories());
        }
    }
}