//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class LoginRequest {
  /// Returns a new [LoginRequest] instance.
  LoginRequest({
    this.email,
    this.password,
    this.twoFactorCode,
    this.twoFactorRecoveryCode,
  });

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? email;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? password;

  String? twoFactorCode;

  String? twoFactorRecoveryCode;

  @override
  bool operator ==(Object other) => identical(this, other) || other is LoginRequest &&
    other.email == email &&
    other.password == password &&
    other.twoFactorCode == twoFactorCode &&
    other.twoFactorRecoveryCode == twoFactorRecoveryCode;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (email == null ? 0 : email!.hashCode) +
    (password == null ? 0 : password!.hashCode) +
    (twoFactorCode == null ? 0 : twoFactorCode!.hashCode) +
    (twoFactorRecoveryCode == null ? 0 : twoFactorRecoveryCode!.hashCode);

  @override
  String toString() => 'LoginRequest[email=$email, password=$password, twoFactorCode=$twoFactorCode, twoFactorRecoveryCode=$twoFactorRecoveryCode]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.email != null) {
      json[r'email'] = this.email;
    } else {
      json[r'email'] = null;
    }
    if (this.password != null) {
      json[r'password'] = this.password;
    } else {
      json[r'password'] = null;
    }
    if (this.twoFactorCode != null) {
      json[r'twoFactorCode'] = this.twoFactorCode;
    } else {
      json[r'twoFactorCode'] = null;
    }
    if (this.twoFactorRecoveryCode != null) {
      json[r'twoFactorRecoveryCode'] = this.twoFactorRecoveryCode;
    } else {
      json[r'twoFactorRecoveryCode'] = null;
    }
    return json;
  }

  /// Returns a new [LoginRequest] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static LoginRequest? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "LoginRequest[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "LoginRequest[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return LoginRequest(
        email: mapValueOfType<String>(json, r'email'),
        password: mapValueOfType<String>(json, r'password'),
        twoFactorCode: mapValueOfType<String>(json, r'twoFactorCode'),
        twoFactorRecoveryCode: mapValueOfType<String>(json, r'twoFactorRecoveryCode'),
      );
    }
    return null;
  }

  static List<LoginRequest> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <LoginRequest>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = LoginRequest.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, LoginRequest> mapFromJson(dynamic json) {
    final map = <String, LoginRequest>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = LoginRequest.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of LoginRequest-objects as value to a dart map
  static Map<String, List<LoginRequest>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<LoginRequest>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = LoginRequest.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

