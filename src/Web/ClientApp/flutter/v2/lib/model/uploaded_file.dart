//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class UploadedFile {
  /// Returns a new [UploadedFile] instance.
  UploadedFile({
    this.id,
    this.domainEvents = const [],
    this.filePath,
    this.fileName,
    this.originalFileName,
    this.contentType,
    this.fileSize,
  });

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? id;

  List<Object> domainEvents;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? filePath;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? fileName;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? originalFileName;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  String? contentType;

  ///
  /// Please note: This property should have been non-nullable! Since the specification file
  /// does not include a default value (using the "default:" property), however, the generated
  /// source code must fall back to having a nullable type.
  /// Consider adding a "default:" property in the specification file to hide this note.
  ///
  int? fileSize;

  @override
  bool operator ==(Object other) => identical(this, other) || other is UploadedFile &&
    other.id == id &&
    _deepEquality.equals(other.domainEvents, domainEvents) &&
    other.filePath == filePath &&
    other.fileName == fileName &&
    other.originalFileName == originalFileName &&
    other.contentType == contentType &&
    other.fileSize == fileSize;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (id == null ? 0 : id!.hashCode) +
    (domainEvents.hashCode) +
    (filePath == null ? 0 : filePath!.hashCode) +
    (fileName == null ? 0 : fileName!.hashCode) +
    (originalFileName == null ? 0 : originalFileName!.hashCode) +
    (contentType == null ? 0 : contentType!.hashCode) +
    (fileSize == null ? 0 : fileSize!.hashCode);

  @override
  String toString() => 'UploadedFile[id=$id, domainEvents=$domainEvents, filePath=$filePath, fileName=$fileName, originalFileName=$originalFileName, contentType=$contentType, fileSize=$fileSize]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.id != null) {
      json[r'id'] = this.id;
    } else {
      json[r'id'] = null;
    }
      json[r'domainEvents'] = this.domainEvents;
    if (this.filePath != null) {
      json[r'filePath'] = this.filePath;
    } else {
      json[r'filePath'] = null;
    }
    if (this.fileName != null) {
      json[r'fileName'] = this.fileName;
    } else {
      json[r'fileName'] = null;
    }
    if (this.originalFileName != null) {
      json[r'originalFileName'] = this.originalFileName;
    } else {
      json[r'originalFileName'] = null;
    }
    if (this.contentType != null) {
      json[r'contentType'] = this.contentType;
    } else {
      json[r'contentType'] = null;
    }
    if (this.fileSize != null) {
      json[r'fileSize'] = this.fileSize;
    } else {
      json[r'fileSize'] = null;
    }
    return json;
  }

  /// Returns a new [UploadedFile] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static UploadedFile? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "UploadedFile[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "UploadedFile[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return UploadedFile(
        id: mapValueOfType<String>(json, r'id'),
        domainEvents: Object.listFromJson(json[r'domainEvents']),
        filePath: mapValueOfType<String>(json, r'filePath'),
        fileName: mapValueOfType<String>(json, r'fileName'),
        originalFileName: mapValueOfType<String>(json, r'originalFileName'),
        contentType: mapValueOfType<String>(json, r'contentType'),
        fileSize: mapValueOfType<int>(json, r'fileSize'),
      );
    }
    return null;
  }

  static List<UploadedFile> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <UploadedFile>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = UploadedFile.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, UploadedFile> mapFromJson(dynamic json) {
    final map = <String, UploadedFile>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = UploadedFile.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of UploadedFile-objects as value to a dart map
  static Map<String, List<UploadedFile>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<UploadedFile>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = UploadedFile.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

