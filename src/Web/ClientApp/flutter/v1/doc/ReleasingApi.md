# openapi.api.ReleasingApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**deleteRelease**](ReleasingApi.md#deleterelease) | **DELETE** /api/Releasing/{carId} | 
[**editRelease**](ReleasingApi.md#editrelease) | **PUT** /api/Releasing/{carId} | 
[**getReleasedCarDetails**](ReleasingApi.md#getreleasedcardetails) | **GET** /api/Releasing/{carId} | 
[**getReleasedCars**](ReleasingApi.md#getreleasedcars) | **GET** /api/Releasing | 
[**releaseCar**](ReleasingApi.md#releasecar) | **POST** /api/Releasing | 


# **deleteRelease**
> ReleaseDto deleteRelease(carId, acceptLanguage)



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

final api_instance = ReleasingApi();
final carId = carId_example; // String | 
final acceptLanguage = []; // List<String> | Language preference for the response.

try {
    final result = api_instance.deleteRelease(carId, acceptLanguage);
    print(result);
} catch (e) {
    print('Exception when calling ReleasingApi->deleteRelease: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **carId** | **String**|  | 
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]

### Return type

[**ReleaseDto**](ReleaseDto.md)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **editRelease**
> ReleaseDto editRelease(carId, editReleaseCommand, acceptLanguage)



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

final api_instance = ReleasingApi();
final carId = carId_example; // String | 
final editReleaseCommand = EditReleaseCommand(); // EditReleaseCommand | 
final acceptLanguage = []; // List<String> | Language preference for the response.

try {
    final result = api_instance.editRelease(carId, editReleaseCommand, acceptLanguage);
    print(result);
} catch (e) {
    print('Exception when calling ReleasingApi->editRelease: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **carId** | **String**|  | 
 **editReleaseCommand** | [**EditReleaseCommand**](EditReleaseCommand.md)|  | 
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]

### Return type

[**ReleaseDto**](ReleaseDto.md)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **getReleasedCarDetails**
> ReleaseDto getReleasedCarDetails(carId, acceptLanguage)



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

final api_instance = ReleasingApi();
final carId = carId_example; // String | 
final acceptLanguage = []; // List<String> | Language preference for the response.

try {
    final result = api_instance.getReleasedCarDetails(carId, acceptLanguage);
    print(result);
} catch (e) {
    print('Exception when calling ReleasingApi->getReleasedCarDetails: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **carId** | **String**|  | 
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]

### Return type

[**ReleaseDto**](ReleaseDto.md)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **getReleasedCars**
> ReleaseVm getReleasedCars(acceptLanguage)



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

final api_instance = ReleasingApi();
final acceptLanguage = []; // List<String> | Language preference for the response.

try {
    final result = api_instance.getReleasedCars(acceptLanguage);
    print(result);
} catch (e) {
    print('Exception when calling ReleasingApi->getReleasedCars: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]

### Return type

[**ReleaseVm**](ReleaseVm.md)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **releaseCar**
> ReleaseDto releaseCar(carId, releaseDate, acceptLanguage, documents)



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

final api_instance = ReleasingApi();
final carId = carId_example; // String | 
final releaseDate = 2013-10-20T19:20:30+01:00; // DateTime | 
final acceptLanguage = []; // List<String> | Language preference for the response.
final documents = BINARY_DATA_HERE; // MultipartFile | 

try {
    final result = api_instance.releaseCar(carId, releaseDate, acceptLanguage, documents);
    print(result);
} catch (e) {
    print('Exception when calling ReleasingApi->releaseCar: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **carId** | **String**|  | 
 **releaseDate** | **DateTime**|  | [optional] 
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]
 **documents** | **MultipartFile**|  | [optional] 

### Return type

[**ReleaseDto**](ReleaseDto.md)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

