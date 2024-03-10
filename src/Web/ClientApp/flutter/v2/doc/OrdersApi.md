# openapi.api.OrdersApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**completeOrder**](OrdersApi.md#completeorder) | **POST** /api/Orders/complete/{id} | 
[**getOrderDetails**](OrdersApi.md#getorderdetails) | **GET** /api/Orders/{id} | 
[**getOrders**](OrdersApi.md#getorders) | **GET** /api/Orders | 
[**launchOrder**](OrdersApi.md#launchorder) | **POST** /api/Orders | 


# **completeOrder**
> CarDto completeOrder(id, acceptLanguage)



### Example
```dart
import 'package:openapi/api.dart';
// TODO Configure API key authorization: JWT
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKeyPrefix = 'Bearer';
// TODO Configure API key authorization: XApiKey
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKeyPrefix = 'Bearer';

final api_instance = OrdersApi();
final id = id_example; // String | 
final acceptLanguage = []; // List<String> | Language preference for the response.

try {
    final result = api_instance.completeOrder(id, acceptLanguage);
    print(result);
} catch (e) {
    print('Exception when calling OrdersApi->completeOrder: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]

### Return type

[**CarDto**](CarDto.md)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **getOrderDetails**
> Object getOrderDetails(id, acceptLanguage)



### Example
```dart
import 'package:openapi/api.dart';
// TODO Configure API key authorization: JWT
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKeyPrefix = 'Bearer';
// TODO Configure API key authorization: XApiKey
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKeyPrefix = 'Bearer';

final api_instance = OrdersApi();
final id = id_example; // String | 
final acceptLanguage = []; // List<String> | Language preference for the response.

try {
    final result = api_instance.getOrderDetails(id, acceptLanguage);
    print(result);
} catch (e) {
    print('Exception when calling OrdersApi->getOrderDetails: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]

### Return type

[**Object**](Object.md)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **getOrders**
> OrderVm getOrders(pageNumber, pageSize, searchString, sortBy, sortOrder, isCompletedOnly, acceptLanguage)



### Example
```dart
import 'package:openapi/api.dart';
// TODO Configure API key authorization: JWT
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKeyPrefix = 'Bearer';
// TODO Configure API key authorization: XApiKey
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKeyPrefix = 'Bearer';

final api_instance = OrdersApi();
final pageNumber = 56; // int | 
final pageSize = 56; // int | 
final searchString = searchString_example; // String | 
final sortBy = sortBy_example; // String | 
final sortOrder = sortOrder_example; // String | 
final isCompletedOnly = true; // bool | 
final acceptLanguage = []; // List<String> | Language preference for the response.

try {
    final result = api_instance.getOrders(pageNumber, pageSize, searchString, sortBy, sortOrder, isCompletedOnly, acceptLanguage);
    print(result);
} catch (e) {
    print('Exception when calling OrdersApi->getOrders: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **pageNumber** | **int**|  | [optional] [default to 1]
 **pageSize** | **int**|  | [optional] [default to 10]
 **searchString** | **String**|  | [optional] [default to '']
 **sortBy** | **String**|  | [optional] [default to 'Date']
 **sortOrder** | **String**|  | [optional] [default to 'asc']
 **isCompletedOnly** | **bool**|  | [optional] [default to false]
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]

### Return type

[**OrderVm**](OrderVm.md)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **launchOrder**
> CarDto launchOrder(modelId, year, colorId, isBroker, userFullName, userNationalityId, releasedAfterInMonths, acceptLanguage)



### Example
```dart
import 'package:openapi/api.dart';
// TODO Configure API key authorization: JWT
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('JWT').apiKeyPrefix = 'Bearer';
// TODO Configure API key authorization: XApiKey
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKey = 'YOUR_API_KEY';
// uncomment below to setup prefix (e.g. Bearer) for API key, if needed
//defaultApiClient.getAuthentication<ApiKeyAuth>('XApiKey').apiKeyPrefix = 'Bearer';

final api_instance = OrdersApi();
final modelId = 56; // int | 
final year = 56; // int | 
final colorId = 56; // int | 
final isBroker = true; // bool | 
final userFullName = userFullName_example; // String | 
final userNationalityId = userNationalityId_example; // String | 
final releasedAfterInMonths = 56; // int | 
final acceptLanguage = []; // List<String> | Language preference for the response.

try {
    final result = api_instance.launchOrder(modelId, year, colorId, isBroker, userFullName, userNationalityId, releasedAfterInMonths, acceptLanguage);
    print(result);
} catch (e) {
    print('Exception when calling OrdersApi->launchOrder: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **modelId** | **int**|  | 
 **year** | **int**|  | 
 **colorId** | **int**|  | 
 **isBroker** | **bool**|  | 
 **userFullName** | **String**|  | 
 **userNationalityId** | **String**|  | 
 **releasedAfterInMonths** | **int**|  | 
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]

### Return type

[**CarDto**](CarDto.md)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

