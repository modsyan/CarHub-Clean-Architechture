# openapi.api.CarsApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**deleteCar**](CarsApi.md#deletecar) | **DELETE** /api/Cars/{id} | 
[**editCar**](CarsApi.md#editcar) | **PUT** /api/Cars/{id} | 
[**getCarDetails**](CarsApi.md#getcardetails) | **GET** /api/Cars/{id} | 
[**getCars**](CarsApi.md#getcars) | **GET** /api/Cars | 


# **deleteCar**
> CarDto deleteCar(id, acceptLanguage)



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

final api_instance = CarsApi();
final id = id_example; // String | 
final acceptLanguage = []; // List<String> | Language preference for the response.

try {
    final result = api_instance.deleteCar(id, acceptLanguage);
    print(result);
} catch (e) {
    print('Exception when calling CarsApi->deleteCar: $e\n');
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

# **editCar**
> CarDto editCar(id, editCarCommand, acceptLanguage)



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

final api_instance = CarsApi();
final id = id_example; // String | 
final editCarCommand = EditCarCommand(); // EditCarCommand | 
final acceptLanguage = []; // List<String> | Language preference for the response.

try {
    final result = api_instance.editCar(id, editCarCommand, acceptLanguage);
    print(result);
} catch (e) {
    print('Exception when calling CarsApi->editCar: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **editCarCommand** | [**EditCarCommand**](EditCarCommand.md)|  | 
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]

### Return type

[**CarDto**](CarDto.md)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **getCarDetails**
> CarDto getCarDetails(id, acceptLanguage)



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

final api_instance = CarsApi();
final id = id_example; // String | 
final acceptLanguage = []; // List<String> | Language preference for the response.

try {
    final result = api_instance.getCarDetails(id, acceptLanguage);
    print(result);
} catch (e) {
    print('Exception when calling CarsApi->getCarDetails: $e\n');
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

# **getCars**
> CarVm getCars(pageNumber, pageSize, searchString, acceptLanguage)



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

final api_instance = CarsApi();
final pageNumber = 56; // int | 
final pageSize = 56; // int | 
final searchString = searchString_example; // String | 
final acceptLanguage = []; // List<String> | Language preference for the response.

try {
    final result = api_instance.getCars(pageNumber, pageSize, searchString, acceptLanguage);
    print(result);
} catch (e) {
    print('Exception when calling CarsApi->getCars: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **pageNumber** | **int**|  | [optional] [default to 1]
 **pageSize** | **int**|  | [optional] [default to 10]
 **searchString** | **String**|  | [optional] [default to '']
 **acceptLanguage** | [**List<String>**](String.md)| Language preference for the response. | [optional] [default to const []]

### Return type

[**CarVm**](CarVm.md)

### Authorization

[JWT](../README.md#JWT), [XApiKey](../README.md#XApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

