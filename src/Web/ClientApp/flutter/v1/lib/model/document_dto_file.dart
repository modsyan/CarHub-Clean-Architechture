//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.12

// ignore_for_file: unused_element, unused_import
// ignore_for_file: always_put_required_named_parameters_first
// ignore_for_file: constant_identifier_names
// ignore_for_file: lines_longer_than_80_chars

part of openapi.api;

class DocumentDtoFile {
  /// Returns a new [DocumentDtoFile] instance.
  DocumentDtoFile({
    this.fileName,
    this.filePath,
    this.originalFileName,
    this.contentType,
  });

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
  String? filePath;

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

  @override
  bool operator ==(Object other) => identical(this, other) || other is DocumentDtoFile &&
    other.fileName == fileName &&
    other.filePath == filePath &&
    other.originalFileName == originalFileName &&
    other.contentType == contentType;

  @override
  int get hashCode =>
    // ignore: unnecessary_parenthesis
    (fileName == null ? 0 : fileName!.hashCode) +
    (filePath == null ? 0 : filePath!.hashCode) +
    (originalFileName == null ? 0 : originalFileName!.hashCode) +
    (contentType == null ? 0 : contentType!.hashCode);

  @override
  String toString() => 'DocumentDtoFile[fileName=$fileName, filePath=$filePath, originalFileName=$originalFileName, contentType=$contentType]';

  Map<String, dynamic> toJson() {
    final json = <String, dynamic>{};
    if (this.fileName != null) {
      json[r'fileName'] = this.fileName;
    } else {
      json[r'fileName'] = null;
    }
    if (this.filePath != null) {
      json[r'filePath'] = this.filePath;
    } else {
      json[r'filePath'] = null;
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
    return json;
  }

  /// Returns a new [DocumentDtoFile] instance and imports its values from
  /// [value] if it's a [Map], null otherwise.
  // ignore: prefer_constructors_over_static_methods
  static DocumentDtoFile? fromJson(dynamic value) {
    if (value is Map) {
      final json = value.cast<String, dynamic>();

      // Ensure that the map contains the required keys.
      // Note 1: the values aren't checked for validity beyond being non-null.
      // Note 2: this code is stripped in release mode!
      assert(() {
        requiredKeys.forEach((key) {
          assert(json.containsKey(key), 'Required key "DocumentDtoFile[$key]" is missing from JSON.');
          assert(json[key] != null, 'Required key "DocumentDtoFile[$key]" has a null value in JSON.');
        });
        return true;
      }());

      return DocumentDtoFile(
        fileName: mapValueOfType<String>(json, r'fileName'),
        filePath: mapValueOfType<String>(json, r'filePath'),
        originalFileName: mapValueOfType<String>(json, r'originalFileName'),
        contentType: mapValueOfType<String>(json, r'contentType'),
      );
    }
    return null;
  }

  static List<DocumentDtoFile> listFromJson(dynamic json, {bool growable = false,}) {
    final result = <DocumentDtoFile>[];
    if (json is List && json.isNotEmpty) {
      for (final row in json) {
        final value = DocumentDtoFile.fromJson(row);
        if (value != null) {
          result.add(value);
        }
      }
    }
    return result.toList(growable: growable);
  }

  static Map<String, DocumentDtoFile> mapFromJson(dynamic json) {
    final map = <String, DocumentDtoFile>{};
    if (json is Map && json.isNotEmpty) {
      json = json.cast<String, dynamic>(); // ignore: parameter_assignments
      for (final entry in json.entries) {
        final value = DocumentDtoFile.fromJson(entry.value);
        if (value != null) {
          map[entry.key] = value;
        }
      }
    }
    return map;
  }

  // maps a json object with a list of DocumentDtoFile-objects as value to a dart map
  static Map<String, List<DocumentDtoFile>> mapListFromJson(dynamic json, {bool growable = false,}) {
    final map = <String, List<DocumentDtoFile>>{};
    if (json is Map && json.isNotEmpty) {
      // ignore: parameter_assignments
      json = json.cast<String, dynamic>();
      for (final entry in json.entries) {
        map[entry.key] = DocumentDtoFile.listFromJson(entry.value, growable: growable,);
      }
    }
    return map;
  }

  /// The list of required keys that must be present in a JSON.
  static const requiredKeys = <String>{
  };
}

