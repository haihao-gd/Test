// @ts-ignore
/* eslint-disable */

declare namespace API {
  type CreateProjectCommand = {
    name?: string;
    creationTime?: string;
  };

  type PermissionGrantModel = {
    name?: string;
    displayName?: string;
    parentName?: string;
    isGranted?: boolean;
    allowedProviders?: string[];
  };

  type PermissionGroupModel = {
    name?: string;
    displayName?: string;
    permissions?: PermissionGrantModel[];
  };

  type PermissionListResponseModel = {
    entityDisplayName?: string;
    groups?: PermissionGroupModel[];
  };

  type PermissionUpdateRequestModel = {
    name?: string;
    isGranted?: boolean;
  };

  type ProductCreateOrUpdateRequestModel = {
    id?: string;
    name?: string;
    creationTime?: string;
  };

  type ProductGetResponseModel = {
    id?: string;
    name?: string;
    creationTime?: string;
  };

  type ProductGetResponseModelPagedResponseModel = {
    items?: ProductGetResponseModel[];
    totalCount?: number;
  };

  type ProjectCreateOrUpdateRequestModel = {
    id?: number;
    name?: string;
    creationTime?: string;
  };

  type ProjectGetResponseModel = {
    id?: number;
    name?: string;
    creationTime?: string;
  };

  type ProjectGetResponseModelPagedResponseModel = {
    items?: ProjectGetResponseModel[];
    totalCount?: number;
  };
}
