﻿namespace CityMall.Specifications.Specifications.SubCategories;
public sealed class AsNoTrackingGetSubCategoryByIdSpecification : Specification<SubCategory>
{
    public AsNoTrackingGetSubCategoryByIdSpecification(string id) : base(sc => sc.Id.Equals(id))
    {
        StopTracking();
    }
}
