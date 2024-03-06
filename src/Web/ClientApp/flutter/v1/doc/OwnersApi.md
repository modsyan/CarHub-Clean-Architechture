# openapi.api.OwnersApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**getOwners**](OwnersApi.md#getowners) | **GET** /api/Owners | 


# **getOwners**
> String getOwners(acceptLanguage)



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

final api_instance = OwnersApi();
final acceptLanguage = []; // List<String> | Language preference for the response.

try {
    final result = api_instance.getOwners(acceptLanguage);
    print(result);
} catch (e) {
    print('Exception when calling OwnersApi->getOwners: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]

### Return type

**String**

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

