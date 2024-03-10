//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class TwoFactorRequest {
  /// Returns a new [TwoFactorRequest] instance.
  TwoFactorRequest({
    this.enable,
    this.twoFactorCode,
    this.resetSharedKey,
    this.resetRecoveryCodes,
    this.forgetMachine,
  });

  bool? enable;

  String? twoFactorCode;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  bool? resetSharedKey;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  bool? resetRecoveryCodes;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  bool? forgetMachine;

  @override
  bool operator ==(Object other) => identical(this, other) || other is TwoFactorRequest &&
    other.enable == enable &&
    other.twoFactorCode == twoFactorCode &&
    other.resetSharedKey == resetSharedKey &&
    other.resetRecoveryCodes == resetRecoveryCodes &&
    other.forgetMachine == forgetMachine;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (enable == null ? 0 : enable!.hashCode) +
    (twoFactorCode == null ? 0 : twoFactorCode!.hashCode) +
    (resetSharedKey == null ? 0 : resetSharedKey!.hashCode) +
    (resetRecoveryCodes == null ? 0 : resetRecoveryCodes!.hashCode) +
    (forgetMachine == null ? 0 : forgetMachine!.hashCode);

  @override
  String toString() => 'TwoFactorRequest[enable=$enable, twoFactorCode=$twoFactorCode, resetSharedKey=$resetSharedKey, resetRecoveryCodes=$resetRecoveryCodes, forgetMachine=$forgetMachine]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.enable != null) {
      json[r'enable'] = this.enable;
    } else {
      json[r'enable'] = null;
    }
    if (this.twoFactorCode != null) {
      json[r'twoFactorCode'] = this.twoFactorCode;
    } else {
      json[r'twoFactorCode'] = null;
    }
    if (this.resetSharedKey != null) {
      json[r'resetSharedKey'] = this.resetSharedKey;
    } else {
      json[r'resetSharedKey'] = null;
    }
    if (this.resetRecoveryCodes != null) {
      json[r'resetRecoveryCodes'] = this.resetRecoveryCodes;
    } else {
      json[r'resetRecoveryCodes'] = null;
    }
    if (this.forgetMachine != null) {
      json[r'forgetMachine'] = this.forgetMachine;
    } else {
      json[r'forgetMachine'] = null;
    }
    return json;
  }

  /// Returns a new [TwoFactorRequest] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static TwoFactorRequest? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "TwoFactorRequest[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "TwoFactorRequest[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return TwoFactorRequest(
        enable: mapValueOfType<bool>(json, r'enable'),
        twoFactorCode: mapValueOfType<String>(json, r'twoFactorCode'),
        resetSharedKey: mapValueOfType<bool>(json, r'resetSharedKey'),
        resetRecoveryCodes: mapValueOfType<bool>(json, r'resetRecoveryCodes'),
        forgetMachine: mapValueOfType<bool>(json, r'forgetMachine'),
      );
    }
    return null;
  }

  static List<TwoFactorRequest> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <TwoFactorRequest>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = TwoFactorRequest.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, TwoFactorRequest> mapFromJson(dynamic json) {
    final map = <String, TwoFactorRequest>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = TwoFactorRequest.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of TwoFactorRequest-objects as value to a dart map
  static Map<String, List<TwoFactorRequest>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<TwoFactorRequest>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = TwoFactorRequest.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

