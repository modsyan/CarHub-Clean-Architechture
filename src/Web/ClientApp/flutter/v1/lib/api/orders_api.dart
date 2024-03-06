//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;


class OrdersApi {
  OrdersApi([ApiClient? apiClient]) : apiClient = apiClient ?? defaultApiClient;

  final ApiClient apiClient;

  /// Performs an HTTP 'POST /api/Orders/complete/{id}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] id (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> completeOrderWithHttpInfo(String id, { List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Orders/complete/{id}'
      .replaceAll('{id}', id);

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    if (acceptLanguage != null) {
      headerParams[r'Accept-Language'] = parameterToString(acceptLanguage);
    }

    const contentTypes = <String>[];


    return apiClient.invokeAPI(
      path,
      'POST',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Parameters:
  ///
  /// * [String] id (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<CarDto?> completeOrder(String id, { List<String>? acceptLanguage, }) async {
    final response = await completeOrderWithHttpInfo(id,  acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'CarDto',) as CarDto;
    
    }
    return null;
  }

  /// Performs an HTTP 'GET /api/Orders/{id}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] id (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> getOrderDetailsWithHttpInfo(String id, { List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Orders/{id}'
      .replaceAll('{id}', id);

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    if (acceptLanguage != null) {
      headerParams[r'Accept-Language'] = parameterToString(acceptLanguage);
    }

    const contentTypes = <String>[];


    return apiClient.invokeAPI(
      path,
      'GET',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Parameters:
  ///
  /// * [String] id (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Object?> getOrderDetails(String id, { List<String>? acceptLanguage, }) async {
    final response = await getOrderDetailsWithHttpInfo(id,  acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'Object',) as Object;
    
    }
    return null;
  }

  /// Performs an HTTP 'GET /api/Orders' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [int] pageNumber:
  ///
  /// * [int] pageSize:
  ///
  /// * [String] searchString:
  ///
  /// * [String] sortBy:
  ///
  /// * [String] sortOrder:
  ///
  /// * [bool] isCompletedOnly:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> getOrdersWithHttpInfo({ int? pageNumber, int? pageSize, String? searchString, String? sortBy, String? sortOrder, bool? isCompletedOnly, List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Orders';

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    if (pageNumber != null) {
      queryParams.addAll(_queryParams('', 'pageNumber', pageNumber));
    }
    if (pageSize != null) {
      queryParams.addAll(_queryParams('', 'pageSize', pageSize));
    }
    if (searchString != null) {
      queryParams.addAll(_queryParams('', 'searchString', searchString));
    }
    if (sortBy != null) {
      queryParams.addAll(_queryParams('', 'sortBy', sortBy));
    }
    if (sortOrder != null) {
      queryParams.addAll(_queryParams('', 'sortOrder', sortOrder));
    }
    if (isCompletedOnly != null) {
      queryParams.addAll(_queryParams('', 'isCompletedOnly', isCompletedOnly));
    }

    if (acceptLanguage != null) {
      headerParams[r'Accept-Language'] = parameterToString(acceptLanguage);
    }

    const contentTypes = <String>[];


    return apiClient.invokeAPI(
      path,
      'GET',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Parameters:
  ///
  /// * [int] pageNumber:
  ///
  /// * [int] pageSize:
  ///
  /// * [String] searchString:
  ///
  /// * [String] sortBy:
  ///
  /// * [String] sortOrder:
  ///
  /// * [bool] isCompletedOnly:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<OrderVm?> getOrders({ int? pageNumber, int? pageSize, String? searchString, String? sortBy, String? sortOrder, bool? isCompletedOnly, List<String>? acceptLanguage, }) async {
    final response = await getOrdersWithHttpInfo( pageNumber: pageNumber, pageSize: pageSize, searchString: searchString, sortBy: sortBy, sortOrder: sortOrder, isCompletedOnly: isCompletedOnly, acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'OrderVm',) as OrderVm;
    
    }
    return null;
  }

  /// Performs an HTTP 'POST /api/Orders' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [int] modelId (required):
  ///
  /// * [int] year (required):
  ///
  /// * [int] colorId (required):
  ///
  /// * [bool] isBroker (required):
  ///
  /// * [String] userFullName (required):
  ///
  /// * [String] userNationalityId (required):
  ///
  /// * [int] releasedAfterInMonths (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> launchOrderWithHttpInfo(int modelId, int year, int colorId, bool isBroker, String userFullName, String userNationalityId, int releasedAfterInMonths, { List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Orders';

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

      queryParams.addAll(_queryParams('', 'ModelId', modelId));
      queryParams.addAll(_queryParams('', 'Year', year));
      queryParams.addAll(_queryParams('', 'ColorId', colorId));
      queryParams.addAll(_queryParams('', 'IsBroker', isBroker));
      queryParams.addAll(_queryParams('', 'UserFullName', userFullName));
      queryParams.addAll(_queryParams('', 'UserNationalityId', userNationalityId));
      queryParams.addAll(_queryParams('', 'ReleasedAfterInMonths', releasedAfterInMonths));

    if (acceptLanguage != null) {
      headerParams[r'Accept-Language'] = parameterToString(acceptLanguage);
    }

    const contentTypes = <String>[];


    return apiClient.invokeAPI(
      path,
      'POST',
      queryParams,
      postBody,
      headerParams,
      formParams,
      contentTypes.isEmpty ? null : contentTypes.first,
    );
  }

  /// Parameters:
  ///
  /// * [int] modelId (required):
  ///
  /// * [int] year (required):
  ///
  /// * [int] colorId (required):
  ///
  /// * [bool] isBroker (required):
  ///
  /// * [String] userFullName (required):
  ///
  /// * [String] userNationalityId (required):
  ///
  /// * [int] releasedAfterInMonths (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<CarDto?> launchOrder(int modelId, int year, int colorId, bool isBroker, String userFullName, String userNationalityId, int releasedAfterInMonths, { List<String>? acceptLanguage, }) async {
    final response = await launchOrderWithHttpInfo(modelId, year, colorId, isBroker, userFullName, userNationalityId, releasedAfterInMonths,  acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'CarDto',) as CarDto;
    
    }
    return null;
  }
}
