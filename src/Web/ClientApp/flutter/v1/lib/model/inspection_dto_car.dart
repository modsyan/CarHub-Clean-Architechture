//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class InspectionDtoCar {
  /// Returns a new [InspectionDtoCar] instance.
  InspectionDtoCar({
    this.id,
    this.makeName,
    this.modelName,
    this.year,
    this.color,
    this.inspectionCount,
    this.documentCount,
    this.status,
  });

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? id;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? makeName;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? modelName;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? year;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? color;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  int? inspectionCount;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  int? documentCount;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? status;

  @override
  bool operator ==(Object other) => identical(this, other) || other is InspectionDtoCar &&
    other.id == id &&
    other.makeName == makeName &&
    other.modelName == modelName &&
    other.year == year &&
    other.color == color &&
    other.inspectionCount == inspectionCount &&
    other.documentCount == documentCount &&
    other.status == status;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (id == null ? 0 : id!.hashCode) +
    (makeName == null ? 0 : makeName!.hashCode) +
    (modelName == null ? 0 : modelName!.hashCode) +
    (year == null ? 0 : year!.hashCode) +
    (color == null ? 0 : color!.hashCode) +
    (inspectionCount == null ? 0 : inspectionCount!.hashCode) +
    (documentCount == null ? 0 : documentCount!.hashCode) +
    (status == null ? 0 : status!.hashCode);

  @override
  String toString() => 'InspectionDtoCar[id=$id, makeName=$makeName, modelName=$modelName, year=$year, color=$color, inspectionCount=$inspectionCount, documentCount=$documentCount, status=$status]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.id != null) {
      json[r'id'] = this.id;
    } else {
      json[r'id'] = null;
    }
    if (this.makeName != null) {
      json[r'makeName'] = this.makeName;
    } else {
      json[r'makeName'] = null;
    }
    if (this.modelName != null) {
      json[r'modelName'] = this.modelName;
    } else {
      json[r'modelName'] = null;
    }
    if (this.year != null) {
      json[r'year'] = this.year;
    } else {
      json[r'year'] = null;
    }
    if (this.color != null) {
      json[r'color'] = this.color;
    } else {
      json[r'color'] = null;
    }
    if (this.inspectionCount != null) {
      json[r'inspectionCount'] = this.inspectionCount;
    } else {
      json[r'inspectionCount'] = null;
    }
    if (this.documentCount != null) {
      json[r'documentCount'] = this.documentCount;
    } else {
      json[r'documentCount'] = null;
    }
    if (this.status != null) {
      json[r'status'] = this.status;
    } else {
      json[r'status'] = null;
    }
    return json;
  }

  /// Returns a new [InspectionDtoCar] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static InspectionDtoCar? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "InspectionDtoCar[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "InspectionDtoCar[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return InspectionDtoCar(
        id: mapValueOfType<String>(json, r'id'),
        makeName: mapValueOfType<String>(json, r'makeName'),
        modelName: mapValueOfType<String>(json, r'modelName'),
        year: mapValueOfType<String>(json, r'year'),
        color: mapValueOfType<String>(json, r'color'),
        inspectionCount: mapValueOfType<int>(json, r'inspectionCount'),
        documentCount: mapValueOfType<int>(json, r'documentCount'),
        status: mapValueOfType<String>(json, r'status'),
      );
    }
    return null;
  }

  static List<InspectionDtoCar> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <InspectionDtoCar>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = InspectionDtoCar.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, InspectionDtoCar> mapFromJson(dynamic json) {
    final map = <String, InspectionDtoCar>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = InspectionDtoCar.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of InspectionDtoCar-objects as value to a dart map
  static Map<String, List<InspectionDtoCar>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<InspectionDtoCar>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = InspectionDtoCar.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

