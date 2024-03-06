//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class TwoFactorResponse {
  /// Returns a new [TwoFactorResponse] instance.
  TwoFactorResponse({
    this.sharedKey,
    this.recoveryCodesLeft,
    this.recoveryCodes = const [],
    this.isTwoFactorEnabled,
    this.isMachineRemembered,
  });

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? sharedKey;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  int? recoveryCodesLeft;

  List<String>? recoveryCodes;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  bool? isTwoFactorEnabled;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  bool? isMachineRemembered;

  @override
  bool operator ==(Object other) => identical(this, other) || other is TwoFactorResponse &&
    other.sharedKey == sharedKey &&
    other.recoveryCodesLeft == recoveryCodesLeft &&
    _deepEquality.equals(other.recoveryCodes, recoveryCodes) &&
    other.isTwoFactorEnabled == isTwoFactorEnabled &&
    other.isMachineRemembered == isMachineRemembered;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (sharedKey == null ? 0 : sharedKey!.hashCode) +
    (recoveryCodesLeft == null ? 0 : recoveryCodesLeft!.hashCode) +
    (recoveryCodes == null ? 0 : recoveryCodes!.hashCode) +
    (isTwoFactorEnabled == null ? 0 : isTwoFactorEnabled!.hashCode) +
    (isMachineRemembered == null ? 0 : isMachineRemembered!.hashCode);

  @override
  String toString() => 'TwoFactorResponse[sharedKey=$sharedKey, recoveryCodesLeft=$recoveryCodesLeft, recoveryCodes=$recoveryCodes, isTwoFactorEnabled=$isTwoFactorEnabled, isMachineRemembered=$isMachineRemembered]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.sharedKey != null) {
      json[r'sharedKey'] = this.sharedKey;
    } else {
      json[r'sharedKey'] = null;
    }
    if (this.recoveryCodesLeft != null) {
      json[r'recoveryCodesLeft'] = this.recoveryCodesLeft;
    } else {
      json[r'recoveryCodesLeft'] = null;
    }
    if (this.recoveryCodes != null) {
      json[r'recoveryCodes'] = this.recoveryCodes;
    } else {
      json[r'recoveryCodes'] = null;
    }
    if (this.isTwoFactorEnabled != null) {
      json[r'isTwoFactorEnabled'] = this.isTwoFactorEnabled;
    } else {
      json[r'isTwoFactorEnabled'] = null;
    }
    if (this.isMachineRemembered != null) {
      json[r'isMachineRemembered'] = this.isMachineRemembered;
    } else {
      json[r'isMachineRemembered'] = null;
    }
    return json;
  }

  /// Returns a new [TwoFactorResponse] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static TwoFactorResponse? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "TwoFactorResponse[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "TwoFactorResponse[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return TwoFactorResponse(
        sharedKey: mapValueOfType<String>(json, r'sharedKey'),
        recoveryCodesLeft: mapValueOfType<int>(json, r'recoveryCodesLeft'),
        recoveryCodes: json[r'recoveryCodes'] is Iterable
            ? (json[r'recoveryCodes'] as Iterable).cast<String>().toList(growable: false)
            : const [],
        isTwoFactorEnabled: mapValueOfType<bool>(json, r'isTwoFactorEnabled'),
        isMachineRemembered: mapValueOfType<bool>(json, r'isMachineRemembered'),
      );
    }
    return null;
  }

  static List<TwoFactorResponse> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <TwoFactorResponse>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = TwoFactorResponse.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, TwoFactorResponse> mapFromJson(dynamic json) {
    final map = <String, TwoFactorResponse>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = TwoFactorResponse.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of TwoFactorResponse-objects as value to a dart map
  static Map<String, List<TwoFactorResponse>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<TwoFactorResponse>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = TwoFactorResponse.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

