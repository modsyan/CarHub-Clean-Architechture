//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class EditCarCommand {
  /// Returns a new [EditCarCommand] instance.
  EditCarCommand({
    this.id,
    this.engineSerialNumber,
    this.modelId,
    this.year,
    this.colorId,
  });

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? id;

  String? engineSerialNumber;

  int? modelId;

  int? year;

  int? colorId;

  @override
  bool operator ==(Object other) => identical(this, other) || other is EditCarCommand &&
    other.id == id &&
    other.engineSerialNumber == engineSerialNumber &&
    other.modelId == modelId &&
    other.year == year &&
    other.colorId == colorId;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (id == null ? 0 : id!.hashCode) +
    (engineSerialNumber == null ? 0 : engineSerialNumber!.hashCode) +
    (modelId == null ? 0 : modelId!.hashCode) +
    (year == null ? 0 : year!.hashCode) +
    (colorId == null ? 0 : colorId!.hashCode);

  @override
  String toString() => 'EditCarCommand[id=$id, engineSerialNumber=$engineSerialNumber, modelId=$modelId, year=$year, colorId=$colorId]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.id != null) {
      json[r'id'] = this.id;
    } else {
      json[r'id'] = null;
    }
    if (this.engineSerialNumber != null) {
      json[r'engineSerialNumber'] = this.engineSerialNumber;
    } else {
      json[r'engineSerialNumber'] = null;
    }
    if (this.modelId != null) {
      json[r'modelId'] = this.modelId;
    } else {
      json[r'modelId'] = null;
    }
    if (this.year != null) {
      json[r'year'] = this.year;
    } else {
      json[r'year'] = null;
    }
    if (this.colorId != null) {
      json[r'colorId'] = this.colorId;
    } else {
      json[r'colorId'] = null;
    }
    return json;
  }

  /// Returns a new [EditCarCommand] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static EditCarCommand? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "EditCarCommand[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "EditCarCommand[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return EditCarCommand(
        id: mapValueOfType<String>(json, r'id'),
        engineSerialNumber: mapValueOfType<String>(json, r'engineSerialNumber'),
        modelId: mapValueOfType<int>(json, r'modelId'),
        year: mapValueOfType<int>(json, r'year'),
        colorId: mapValueOfType<int>(json, r'colorId'),
      );
    }
    return null;
  }

  static List<EditCarCommand> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <EditCarCommand>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = EditCarCommand.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, EditCarCommand> mapFromJson(dynamic json) {
    final map = <String, EditCarCommand>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = EditCarCommand.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of EditCarCommand-objects as value to a dart map
  static Map<String, List<EditCarCommand>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<EditCarCommand>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = EditCarCommand.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

