//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;


class DocumentsApi {
  DocumentsApi([ApiClient? apiClient]) : apiClient = apiClient ?? defaultApiClient;

  final ApiClient apiClient;

  /// Performs an HTTP 'POST /api/Documents' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] carId (required):
  ///
  /// * [String] title (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [MultipartFile] files:
  Future<Response> createDocumentWithHttpInfo(String carId, String title, { List<String>? acceptLanguage, MultipartFile? files, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Documents';

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

      queryParams.addAll(_queryParams('', 'carId', carId));
      queryParams.addAll(_queryParams('', 'title', title));

    if (acceptLanguage != null) {
      headerParams[r'Accept-Language'] = parameterToString(acceptLanguage);
    }

    const contentTypes = <String>['multipart/form-data'];

    bool hasFields = false;
    final mp = MultipartRequest('POST', Uri.parse(path));
    if (files != null) {
      hasFields = true;
      mp.fields[r'files'] = files.field;
      mp.files.add(files);
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
  /// * [String] title (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [MultipartFile] files:
  Future<CarDto?> createDocument(String carId, String title, { List<String>? acceptLanguage, MultipartFile? files, }) async {
    final response = await createDocumentWithHttpInfo(carId, title,  acceptLanguage: acceptLanguage, files: files, );
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

  /// Performs an HTTP 'POST /api/Documents/List' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] carId (required):
  ///
  /// * [List<String>] titles (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [List<Object>] files:
  Future<Response> createManyDocumentsWithHttpInfo(String carId, List<String> titles, { List<String>? acceptLanguage, List<Object>? files, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Documents/List';

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

      queryParams.addAll(_queryParams('', 'carId', carId));
      queryParams.addAll(_queryParams('multi', 'titles', titles));

    if (acceptLanguage != null) {
      headerParams[r'Accept-Language'] = parameterToString(acceptLanguage);
    }

    const contentTypes = <String>['multipart/form-data'];

    bool hasFields = false;
    final mp = MultipartRequest('POST', Uri.parse(path));
    if (files != null) {
      hasFields = true;
      mp.fields[r'files'] = parameterToString(files);
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
  /// * [List<String>] titles (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [List<Object>] files:
  Future<CarDto?> createManyDocuments(String carId, List<String> titles, { List<String>? acceptLanguage, List<Object>? files, }) async {
    final response = await createManyDocumentsWithHttpInfo(carId, titles,  acceptLanguage: acceptLanguage, files: files, );
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

  /// Performs an HTTP 'DELETE /api/Documents/{id}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] id (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> deleteDocumentWithHttpInfo(String id, { List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Documents/{id}'
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
  Future<bool?> deleteDocument(String id, { List<String>? acceptLanguage, }) async {
    final response = await deleteDocumentWithHttpInfo(id,  acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'bool',) as bool;
    
    }
    return null;
  }

  /// Performs an HTTP 'DELETE /api/Documents/Trash/Delete/{id}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] id (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> deleteDocumentPermanentlyWithHttpInfo(String id, { List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Documents/Trash/Delete/{id}'
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
  Future<bool?> deleteDocumentPermanently(String id, { List<String>? acceptLanguage, }) async {
    final response = await deleteDocumentPermanentlyWithHttpInfo(id,  acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'bool',) as bool;
    
    }
    return null;
  }

  /// Performs an HTTP 'DELETE /api/Documents/List' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [List<String>] documentIds (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> deleteManyDocumentsWithHttpInfo(List<String> documentIds, { List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Documents/List';

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

      queryParams.addAll(_queryParams('multi', 'documentIds', documentIds));

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
  /// * [List<String>] documentIds (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<bool?> deleteManyDocuments(List<String> documentIds, { List<String>? acceptLanguage, }) async {
    final response = await deleteManyDocumentsWithHttpInfo(documentIds,  acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'bool',) as bool;
    
    }
    return null;
  }

  /// Performs an HTTP 'PUT /api/Documents/{id}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] id (required):
  ///
  /// * [String] title:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [MultipartFile] file:
  Future<Response> editDocumentWithHttpInfo(String id, { String? title, List<String>? acceptLanguage, MultipartFile? file, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Documents/{id}'
      .replaceAll('{id}', id);

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    if (title != null) {
      queryParams.addAll(_queryParams('', 'title', title));
    }

    if (acceptLanguage != null) {
      headerParams[r'Accept-Language'] = parameterToString(acceptLanguage);
    }

    const contentTypes = <String>['multipart/form-data'];

    bool hasFields = false;
    final mp = MultipartRequest('PUT', Uri.parse(path));
    if (file != null) {
      hasFields = true;
      mp.fields[r'file'] = file.field;
      mp.files.add(file);
    }
    if (hasFields) {
      postBody = mp;
    }

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
  /// * [String] title:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  ///
  /// * [MultipartFile] file:
  Future<CarDto?> editDocument(String id, { String? title, List<String>? acceptLanguage, MultipartFile? file, }) async {
    final response = await editDocumentWithHttpInfo(id,  title: title, acceptLanguage: acceptLanguage, file: file, );
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

  /// Performs an HTTP 'DELETE /api/Documents/Trash/Delete' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] carId (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> emptyDocumentTrashWithHttpInfo(String carId, { List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Documents/Trash/Delete';

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

      queryParams.addAll(_queryParams('', 'carId', carId));

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
  Future<bool?> emptyDocumentTrash(String carId, { List<String>? acceptLanguage, }) async {
    final response = await emptyDocumentTrashWithHttpInfo(carId,  acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'bool',) as bool;
    
    }
    return null;
  }

  /// Performs an HTTP 'GET /api/Documents/Trash' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] carId:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> getDocumentsFromTrashWithHttpInfo({ String? carId, List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Documents/Trash';

    // ignore: prefer_final_locals
    Object? postBody;

    final queryParams = <QueryParam>[];
    final headerParams = <String, String>{};
    final formParams = <String, String>{};

    if (carId != null) {
      queryParams.addAll(_queryParams('', 'carId', carId));
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
  /// * [String] carId:
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<PaginatedListOfDocumentDto?> getDocumentsFromTrash({ String? carId, List<String>? acceptLanguage, }) async {
    final response = await getDocumentsFromTrashWithHttpInfo( carId: carId, acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'PaginatedListOfDocumentDto',) as PaginatedListOfDocumentDto;
    
    }
    return null;
  }

  /// Performs an HTTP 'POST /api/Documents/Trash/Restore/{id}' operation and returns the [Response].
  /// Parameters:
  ///
  /// * [String] id (required):
  ///
  /// * [List<String>] acceptLanguage:
  ///   Language preference for the response.
  Future<Response> restoreDocumentFromTrashWithHttpInfo(String id, { List<String>? acceptLanguage, }) async {
    // ignore: prefer_const_declarations
    final path = r'/api/Documents/Trash/Restore/{id}'
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
  Future<bool?> restoreDocumentFromTrash(String id, { List<String>? acceptLanguage, }) async {
    final response = await restoreDocumentFromTrashWithHttpInfo(id,  acceptLanguage: acceptLanguage, );
    if (response.statusCode >= HttpStatus.badRequest) {
      throw ApiException(response.statusCode, await _decodeBodyBytes(response));
    }
    // When a remote server returns no body with a status of 204, we shall not decode it.
    // At the time of writing this, `dart:convert` will throw an "Unexpected end of input"
    // FormatException when trying to decode an empty string.
    if (response.body.isNotEmpty && response.statusCode != HttpStatus.noContent) {
      return await apiClient.deserializeAsync(await _decodeBodyBytes(response), 'bool',) as bool;
    
    }
    return null;
  }
}
