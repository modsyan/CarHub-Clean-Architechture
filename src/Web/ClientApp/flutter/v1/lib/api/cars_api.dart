//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;


class CarsApi {
  CarsApi([ApiClient? apiClient]) : apiClient = apiClient ?? defaultApiClient;

  final ApiClient apiClient;

  /// Performs an HTTP 'DELETE /api/Cars/{id}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] id (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> deleteCarWithHttpInfo(String id, { List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Cars/{id}'
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
      'DELETE',
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
  Future<CarDto?> deleteCar(String id, { List<String>? acceptLanguage, }) async {
    final response = await deleteCarWithHttpInfo(id,  acceptLanguage: acceptLanguage, );
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

  /// Performs an HTTP 'PUT /api/Cars/{id}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] id (required):
  ///
  /// * [EditCarCommand] editCarCommand (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> editCarWithHttpInfo(String id, EditCarCommand editCarCommand, { List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Cars/{id}'
      .replaceAll('{id}', id);

    // ignore: prefer_final_locals
    Object? postBody = editCarCommand;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    if (acceptLanguage != null) {
      headerParams[r'Accept-Language'] = parameterToString(acceptLanguage);
    }

    const contentTypes = <String>['application/json'];


    return apiClient.invokeAPI(
      path,
      'PUT',
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
  /// * [EditCarCommand] editCarCommand (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<CarDto?> editCar(String id, EditCarCommand editCarCommand, { List<String>? acceptLanguage, }) async {
    final response = await editCarWithHttpInfo(id, editCarCommand,  acceptLanguage: acceptLanguage, );
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

  /// Performs an HTTP 'GET /api/Cars/{id}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] id (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> getCarDetailsWithHttpInfo(String id, { List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Cars/{id}'
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
  Future<CarDto?> getCarDetails(String id, { List<String>? acceptLanguage, }) async {
    final response = await getCarDetailsWithHttpInfo(id,  acceptLanguage: acceptLanguage, );
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

  /// Performs an HTTP 'GET /api/Cars' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [int] pageNumber:
  ///
  /// * [int] pageSize:
  ///
  /// * [String] searchString:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> getCarsWithHttpInfo({ int? pageNumber, int? pageSize, String? searchString, List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Cars';

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
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<CarVm?> getCars({ int? pageNumber, int? pageSize, String? searchString, List<String>? acceptLanguage, }) async {
    final response = await getCarsWithHttpInfo( pageNumber: pageNumber, pageSize: pageSize, searchString: searchString, acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'CarVm',) as CarVm;
    
    }
    return null;
  }
}
