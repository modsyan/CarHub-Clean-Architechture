//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class EditBrokerCommand {
  /// Returns a new [EditBrokerCommand] instance.
  EditBrokerCommand({
    this.id,
    this.name,
    this.username,
    this.email,
    this.phoneNumber,
    this.nationalId,
    this.profilePicture,
  });

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? id;

  String? name;

  String? username;

  String? email;

  String? phoneNumber;

  String? nationalId;

  MultipartFile? profilePicture;

  @override
  bool operator ==(Object other) => identical(this, other) || other is EditBrokerCommand &&
    other.id == id &&
    other.name == name &&
    other.username == username &&
    other.email == email &&
    other.phoneNumber == phoneNumber &&
    other.nationalId == nationalId &&
    other.profilePicture == profilePicture;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (id == null ? 0 : id!.hashCode) +
    (name == null ? 0 : name!.hashCode) +
    (username == null ? 0 : username!.hashCode) +
    (email == null ? 0 : email!.hashCode) +
    (phoneNumber == null ? 0 : phoneNumber!.hashCode) +
    (nationalId == null ? 0 : nationalId!.hashCode) +
    (profilePicture == null ? 0 : profilePicture!.hashCode);

  @override
  String toString() => 'EditBrokerCommand[id=$id, name=$name, username=$username, email=$email, phoneNumber=$phoneNumber, nationalId=$nationalId, profilePicture=$profilePicture]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.id != null) {
      json[r'id'] = this.id;
    } else {
      json[r'id'] = null;
    }
    if (this.name != null) {
      json[r'name'] = this.name;
    } else {
      json[r'name'] = null;
    }
    if (this.username != null) {
      json[r'username'] = this.username;
    } else {
      json[r'username'] = null;
    }
    if (this.email != null) {
      json[r'email'] = this.email;
    } else {
      json[r'email'] = null;
    }
    if (this.phoneNumber != null) {
      json[r'phoneNumber'] = this.phoneNumber;
    } else {
      json[r'phoneNumber'] = null;
    }
    if (this.nationalId != null) {
      json[r'nationalId'] = this.nationalId;
    } else {
      json[r'nationalId'] = null;
    }
    if (this.profilePicture != null) {
      json[r'profilePicture'] = this.profilePicture;
    } else {
      json[r'profilePicture'] = null;
    }
    return json;
  }

  /// Returns a new [EditBrokerCommand] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static EditBrokerCommand? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "EditBrokerCommand[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "EditBrokerCommand[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return EditBrokerCommand(
        id: mapValueOfType<String>(json, r'id'),
        name: mapValueOfType<String>(json, r'name'),
        username: mapValueOfType<String>(json, r'username'),
        email: mapValueOfType<String>(json, r'email'),
        phoneNumber: mapValueOfType<String>(json, r'phoneNumber'),
        nationalId: mapValueOfType<String>(json, r'nationalId'),
        profilePicture: null, // No support for decoding binary content from JSON
      );
    }
    return null;
  }

  static List<EditBrokerCommand> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <EditBrokerCommand>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = EditBrokerCommand.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, EditBrokerCommand> mapFromJson(dynamic json) {
    final map = <String, EditBrokerCommand>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = EditBrokerCommand.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of EditBrokerCommand-objects as value to a dart map
  static Map<String, List<EditBrokerCommand>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<EditBrokerCommand>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = EditBrokerCommand.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

