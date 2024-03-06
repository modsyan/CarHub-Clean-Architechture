//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class PaginatedListOfDocumentDto {
  /// Returns a new [PaginatedListOfDocumentDto] instance.
  PaginatedListOfDocumentDto({
    this.items = const [],
    this.pageNumber,
    this.totalPages,
    this.totalCount,
    this.hasPreviousPage,
    this.hasNextPage,
  });

  List<DocumentDto> items;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  int? pageNumber;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  int? totalPages;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  int? totalCount;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  bool? hasPreviousPage;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  bool? hasNextPage;

  @override
  bool operator ==(Object other) => identical(this, other) || other is PaginatedListOfDocumentDto &&
    _deepEquality.equals(other.items, items) &&
    other.pageNumber == pageNumber &&
    other.totalPages == totalPages &&
    other.totalCount == totalCount &&
    other.hasPreviousPage == hasPreviousPage &&
    other.hasNextPage == hasNextPage;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (items.hashCode) +
    (pageNumber == null ? 0 : pageNumber!.hashCode) +
    (totalPages == null ? 0 : totalPages!.hashCode) +
    (totalCount == null ? 0 : totalCount!.hashCode) +
    (hasPreviousPage == null ? 0 : hasPreviousPage!.hashCode) +
    (hasNextPage == null ? 0 : hasNextPage!.hashCode);

  @override
  String toString() => 'PaginatedListOfDocumentDto[items=$items, pageNumber=$pageNumber, totalPages=$totalPages, totalCount=$totalCount, hasPreviousPage=$hasPreviousPage, hasNextPage=$hasNextPage]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
      json[r'items'] = this.items;
    if (this.pageNumber != null) {
      json[r'pageNumber'] = this.pageNumber;
    } else {
      json[r'pageNumber'] = null;
    }
    if (this.totalPages != null) {
      json[r'totalPages'] = this.totalPages;
    } else {
      json[r'totalPages'] = null;
    }
    if (this.totalCount != null) {
      json[r'totalCount'] = this.totalCount;
    } else {
      json[r'totalCount'] = null;
    }
    if (this.hasPreviousPage != null) {
      json[r'hasPreviousPage'] = this.hasPreviousPage;
    } else {
      json[r'hasPreviousPage'] = null;
    }
    if (this.hasNextPage != null) {
      json[r'hasNextPage'] = this.hasNextPage;
    } else {
      json[r'hasNextPage'] = null;
    }
    return json;
  }

  /// Returns a new [PaginatedListOfDocumentDto] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static PaginatedListOfDocumentDto? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "PaginatedListOfDocumentDto[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "PaginatedListOfDocumentDto[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return PaginatedListOfDocumentDto(
        items: DocumentDto.listFromJson(json[r'items']),
        pageNumber: mapValueOfType<int>(json, r'pageNumber'),
        totalPages: mapValueOfType<int>(json, r'totalPages'),
        totalCount: mapValueOfType<int>(json, r'totalCount'),
        hasPreviousPage: mapValueOfType<bool>(json, r'hasPreviousPage'),
        hasNextPage: mapValueOfType<bool>(json, r'hasNextPage'),
      );
    }
    return null;
  }

  static List<PaginatedListOfDocumentDto> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <PaginatedListOfDocumentDto>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = PaginatedListOfDocumentDto.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, PaginatedListOfDocumentDto> mapFromJson(dynamic json) {
    final map = <String, PaginatedListOfDocumentDto>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = PaginatedListOfDocumentDto.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of PaginatedListOfDocumentDto-objects as value to a dart map
  static Map<String, List<PaginatedListOfDocumentDto>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<PaginatedListOfDocumentDto>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = PaginatedListOfDocumentDto.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

