﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WealthParkApi.Filters
{
    public delegate IQueryable<TItem> QueryMutator<TItem, TSearch>(IQueryable<TItem> items, TSearch search);

    /// <summary>
    /// Query mutator for search filter (using strategy design pattern)
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <typeparam name="TSearch"></typeparam>
    public class SearchFieldMutator<TItem, TSearch>
    {
        public Predicate<TSearch> Condition { get; set; }
        public QueryMutator<TItem, TSearch> Mutator { get; set; }

        public SearchFieldMutator(Predicate<TSearch> condition, QueryMutator<TItem, TSearch> mutator)
        {
            Condition = condition;
            Mutator = mutator;
        }

        public IQueryable<TItem> Apply(TSearch search, IQueryable<TItem> query)
        {
            return Condition(search) ? Mutator(query, search) : query;
        }
    }
