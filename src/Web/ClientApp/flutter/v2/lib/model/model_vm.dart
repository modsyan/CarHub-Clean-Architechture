//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class ModelVm {
  /// Returns a new [ModelVm] instance.
  ModelVm({
    this.models = const [],
    this.totalCount,
    this.pageSize,
    this.totalPages,
    this.totalItems,
  });

  List<ModelDto> models;

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
  int? pageSize;

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
  int? totalItems;

  @override
  bool operator ==(Object other) => identical(this, other) || other is ModelVm &&
    _deepEquality.equals(other.models, models) &&
    other.totalCount == totalCount &&
    other.pageSize == pageSize &&
    other.totalPages == totalPages &&
    other.totalItems == totalItems;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (models.hashCode) +
    (totalCount == null ? 0 : totalCount!.hashCode) +
    (pageSize == null ? 0 : pageSize!.hashCode) +
    (totalPages == null ? 0 : totalPages!.hashCode) +
    (totalItems == null ? 0 : totalItems!.hashCode);

  @override
  String toString() => 'ModelVm[models=$models, totalCount=$totalCount, pageSize=$pageSize, totalPages=$totalPages, totalItems=$totalItems]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
      json[r'models'] = this.models;
    if (this.totalCount != null) {
      json[r'totalCount'] = this.totalCount;
    } else {
      json[r'totalCount'] = null;
    }
    if (this.pageSize != null) {
      json[r'pageSize'] = this.pageSize;
    } else {
      json[r'pageSize'] = null;
    }
    if (this.totalPages != null) {
      json[r'totalPages'] = this.totalPages;
    } else {
      json[r'totalPages'] = null;
    }
    if (this.totalItems != null) {
      json[r'totalItems'] = this.totalItems;
    } else {
      json[r'totalItems'] = null;
    }
    return json;
  }

  /// Returns a new [ModelVm] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static ModelVm? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "ModelVm[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "ModelVm[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return ModelVm(
        models: ModelDto.listFromJson(json[r'models']),
        totalCount: mapValueOfType<int>(json, r'totalCount'),
        pageSize: mapValueOfType<int>(json, r'pageSize'),
        totalPages: mapValueOfType<int>(json, r'totalPages'),
        totalItems: mapValueOfType<int>(json, r'totalItems'),
      );
    }
    return null;
  }

  static List<ModelVm> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <ModelVm>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = ModelVm.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, ModelVm> mapFromJson(dynamic json) {
    final map = <String, ModelVm>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = ModelVm.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of ModelVm-objects as value to a dart map
  static Map<String, List<ModelVm>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<ModelVm>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = ModelVm.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

