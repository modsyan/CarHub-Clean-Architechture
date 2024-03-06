# openapi.api.UpComingEventsApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**getUpcomingEventDetails**](UpComingEventsApi.md#getupcomingeventdetails) | **GET** /api/UpComingEvents/{date} | 
[**getUpcomingEvents**](UpComingEventsApi.md#getupcomingevents) | **GET** /api/UpComingEvents | 


# **getUpcomingEventDetails**
> UpcomingEventVm getUpcomingEventDetails(date, acceptLanguage)



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

final api_instance = UpComingEventsApi();
final date = 2013-10-20T19:20:30+01:00; // DateTime | 
final acceptLanguage = []; // List<String> | Language preference for the response.

try {
    final result = api_instance.getUpcomingEventDetails(date, acceptLanguage);
    print(result);
} catch (e) {
    print('Exception when calling UpComingEventsApi->getUpcomingEventDetails: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **date** | **DateTime**|  | 
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]

### Return type

[**UpcomingEventVm**](UpcomingEventVm.md)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **getUpcomingEvents**
> UpcomingEventVm getUpcomingEvents(startDate, endDate, pageNumber, pageSize, sortOrder, acceptLanguage)



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

final api_instance = UpComingEventsApi();
final startDate = 2013-10-20T19:20:30+01:00; // DateTime | 
final endDate = 2013-10-20T19:20:30+01:00; // DateTime | 
final pageNumber = 56; // int | 
final pageSize = 56; // int | 
final sortOrder = sortOrder_example; // String | 
final acceptLanguage = []; // List<String> | Language preference for the response.

try {
    final result = api_instance.getUpcomingEvents(startDate, endDate, pageNumber, pageSize, sortOrder, acceptLanguage);
    print(result);
} catch (e) {
    print('Exception when calling UpComingEventsApi->getUpcomingEvents: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **startDate** | **DateTime**|  | [optional] 
 **endDate** | **DateTime**|  | [optional] 
 **pageNumber** | **int**|  | [optional] [default to 1]
 **pageSize** | **int**|  | [optional] [default to 10]
 **sortOrder** | **String**|  | [optional] [default to 'asc']
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]

### Return type

[**UpcomingEventVm**](UpcomingEventVm.md)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

