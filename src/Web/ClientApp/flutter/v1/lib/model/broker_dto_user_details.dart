//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class BrokerDtoUserDetails {
  /// Returns a new [BrokerDtoUserDetails] instance.
  BrokerDtoUserDetails({
    this.id,
    this.userName,
    this.email,
    this.phoneNumber,
    this.profilePicture,
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
  String? userName;

  String? email;

  String? phoneNumber;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? profilePicture;

  @override
  bool operator ==(Object other) => identical(this, other) || other is BrokerDtoUserDetails &&
    other.id == id &&
    other.userName == userName &&
    other.email == email &&
    other.phoneNumber == phoneNumber &&
    other.profilePicture == profilePicture;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (id == null ? 0 : id!.hashCode) +
    (userName == null ? 0 : userName!.hashCode) +
    (email == null ? 0 : email!.hashCode) +
    (phoneNumber == null ? 0 : phoneNumber!.hashCode) +
    (profilePicture == null ? 0 : profilePicture!.hashCode);

  @override
  String toString() => 'BrokerDtoUserDetails[id=$id, userName=$userName, email=$email, phoneNumber=$phoneNumber, profilePicture=$profilePicture]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.id != null) {
      json[r'id'] = this.id;
    } else {
      json[r'id'] = null;
    }
    if (this.userName != null) {
      json[r'userName'] = this.userName;
    } else {
      json[r'userName'] = null;
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
    if (this.profilePicture != null) {
      json[r'profilePicture'] = this.profilePicture;
    } else {
      json[r'profilePicture'] = null;
    }
    return json;
  }

  /// Returns a new [BrokerDtoUserDetails] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static BrokerDtoUserDetails? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "BrokerDtoUserDetails[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "BrokerDtoUserDetails[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return BrokerDtoUserDetails(
        id: mapValueOfType<String>(json, r'id'),
        userName: mapValueOfType<String>(json, r'userName'),
        email: mapValueOfType<String>(json, r'email'),
        phoneNumber: mapValueOfType<String>(json, r'phoneNumber'),
        profilePicture: mapValueOfType<String>(json, r'profilePicture'),
      );
    }
    return null;
  }

  static List<BrokerDtoUserDetails> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <BrokerDtoUserDetails>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = BrokerDtoUserDetails.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, BrokerDtoUserDetails> mapFromJson(dynamic json) {
    final map = <String, BrokerDtoUserDetails>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = BrokerDtoUserDetails.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of BrokerDtoUserDetails-objects as value to a dart map
  static Map<String, List<BrokerDtoUserDetails>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<BrokerDtoUserDetails>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = BrokerDtoUserDetails.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

