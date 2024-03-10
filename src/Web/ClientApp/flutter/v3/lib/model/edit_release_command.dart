//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class EditReleaseCommand {
  /// Returns a new [EditReleaseCommand] instance.
  EditReleaseCommand({
    this.carId,
  });

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? carId;

  @override
  bool operator ==(Object other) => identical(this, other) || other is EditReleaseCommand &&
    other.carId == carId;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (carId == null ? 0 : carId!.hashCode);

  @override
  String toString() => 'EditReleaseCommand[carId=$carId]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.carId != null) {
      json[r'carId'] = this.carId;
    } else {
      json[r'carId'] = null;
    }
    return json;
  }

  /// Returns a new [EditReleaseCommand] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static EditReleaseCommand? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "EditReleaseCommand[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "EditReleaseCommand[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return EditReleaseCommand(
        carId: mapValueOfType<String>(json, r'carId'),
      );
    }
    return null;
  }

  static List<EditReleaseCommand> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <EditReleaseCommand>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = EditReleaseCommand.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, EditReleaseCommand> mapFromJson(dynamic json) {
    final map = <String, EditReleaseCommand>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = EditReleaseCommand.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of EditReleaseCommand-objects as value to a dart map
  static Map<String, List<EditReleaseCommand>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<EditReleaseCommand>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = EditReleaseCommand.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

