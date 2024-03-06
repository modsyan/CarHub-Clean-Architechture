//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;


class ReleasingApi {
  ReleasingApi([ApiClient? apiClient]) : apiClient = apiClient ?? defaultApiClient;

  final ApiClient apiClient;

  /// Performs an HTTP 'DELETE /api/Releasing/{carId}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] carId (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> deleteReleaseWithHttpInfo(String carId, { List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Releasing/{carId}'
      .replaceAll('{carId}', carId);

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
  /// * [String] carId (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<ReleaseDto?> deleteRelease(String carId, { List<String>? acceptLanguage, }) async {
    final response = await deleteReleaseWithHttpInfo(carId,  acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'ReleaseDto',) as ReleaseDto;
    
    }
    return null;
  }

  /// Performs an HTTP 'PUT /api/Releasing/{carId}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] carId (required):
  ///
  /// * [EditReleaseCommand] editReleaseCommand (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> editReleaseWithHttpInfo(String carId, EditReleaseCommand editReleaseCommand, { List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Releasing/{carId}'
      .replaceAll('{carId}', carId);

    // ignore: prefer_final_locals
    Object? postBody = editReleaseCommand;

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
  /// * [String] carId (required):
  ///
  /// * [EditReleaseCommand] editReleaseCommand (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<ReleaseDto?> editRelease(String carId, EditReleaseCommand editReleaseCommand, { List<String>? acceptLanguage, }) async {
    final response = await editReleaseWithHttpInfo(carId, editReleaseCommand,  acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'ReleaseDto',) as ReleaseDto;
    
    }
    return null;
  }

  /// Performs an HTTP 'GET /api/Releasing/{carId}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] carId (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> getReleasedCarDetailsWithHttpInfo(String carId, { List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Releasing/{carId}'
      .replaceAll('{carId}', carId);

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
  /// * [String] carId (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<ReleaseDto?> getReleasedCarDetails(String carId, { List<String>? acceptLanguage, }) async {
    final response = await getReleasedCarDetailsWithHttpInfo(carId,  acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'ReleaseDto',) as ReleaseDto;
    
    }
    return null;
  }

  /// Performs an HTTP 'GET /api/Releasing' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> getReleasedCarsWithHttpInfo({ List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Releasing';

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
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<ReleaseVm?> getReleasedCars({ List<String>? acceptLanguage, }) async {
    final response = await getReleasedCarsWithHttpInfo( acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'ReleaseVm',) as ReleaseVm;
    
    }
    return null;
  }

  /// Performs an HTTP 'POST /api/Releasing' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] carId (required):
  ///
  /// * [DateTime] releaseDate:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [MultipartFile] documents:
  Future<Response> releaseCarWithHttpInfo(String carId, { DateTime? releaseDate, List<String>? acceptLanguage, MultipartFile? documents, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Releasing';

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

      queryParams.addAll(_queryParams('', 'carId', carId));
    if (releaseDate != null) {
      queryParams.addAll(_queryParams('', 'releaseDate', releaseDate));
    }

    if (acceptLanguage != null) {
      headerParams[r'Accept-Language'] = parameterToString(acceptLanguage);
    }

    const contentTypes = <String>['multipart/form-data'];

    bool hasFields = false;
    final mp = MultipartRequest('POST', Uri.parse(path));
    if (documents != null) {
      hasFields = true;
      mp.fields[r'documents'] = documents.field;
      mp.files.add(documents);
    }
    if (hasFields) {
      postBody = mp;
    }

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
  /// * [String] carId (required):
  ///
  /// * [DateTime] releaseDate:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [MultipartFile] documents:
  Future<ReleaseDto?> releaseCar(String carId, { DateTime? releaseDate, List<String>? acceptLanguage, MultipartFile? documents, }) async {
    final response = await releaseCarWithHttpInfo(carId,  releaseDate: releaseDate, acceptLanguage: acceptLanguage, documents: documents, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'ReleaseDto',) as ReleaseDto;
    
    }
    return null;
  }
}
