XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
ROOT=$(PWD)
PROJECTNAME=LNTouchVisualizer
PROJECT_ROOT=$(ROOT)/../external/$(PROJECTNAME)
PROJECT=$(PROJECT_ROOT)/$(PROJECTNAME)/$(PROJECTNAME).xcodeproj
BUILD_ROOT=$(PROJECT_ROOT)/build
TARGET_IOS=$(PROJECTNAME)
OUTPUT=$(ROOT)/Build
FRAMEWORK_PATH=Products/Library/Frameworks/$(PROJECTNAME).framework
FRAMEWORKS=$(ROOT)/Frameworks
IOS_SDK=iphoneos16.1
BINDING_OUTPUT=$(ROOT)/../bindings

framework: iossimulator iosdevice maccatalyst xcframework

iossimulator:
	$(XBUILD) archive ONLY_ACTIVE_ARCH=NO -project $(PROJECT) -scheme $(TARGET_IOS) -destination "generic/platform=iOS Simulator" -archivePath $(BUILD_ROOT)/simulator.xcarchive -sdk iphonesimulator SKIP_INSTALL=NO BUILD_LIBRARY_FOR_DISTRIBUTION=YES

iosdevice:
	$(XBUILD) archive ONLY_ACTIVE_ARCH=NO -project $(PROJECT) -scheme $(TARGET_IOS) -destination "generic/platform=iOS" -archivePath $(BUILD_ROOT)/iOS.xcarchive -sdk iphoneos SKIP_INSTALL=NO BUILD_LIBRARY_FOR_DISTRIBUTION=YES

maccatalyst:
	$(XBUILD) archive ONLY_ACTIVE_ARCH=NO -project $(PROJECT) -scheme $(TARGET_IOS) -destination "generic/platform=macOS,variant=Mac Catalyst" -archivePath $(BUILD_ROOT)/catalyst.xcarchive SKIP_INSTALL=NO BUILD_LIBRARY_FOR_DISTRIBUTION=YES

xcframework:
	rm -rf $(BUILD_ROOT)/$(PROJECTNAME).xcframework
	$(XBUILD) -create-xcframework -framework $(BUILD_ROOT)/simulator.xcarchive/$(FRAMEWORK_PATH) -framework $(BUILD_ROOT)/iOS.xcarchive/$(FRAMEWORK_PATH) -framework $(BUILD_ROOT)/catalyst.xcarchive/$(FRAMEWORK_PATH) -output $(BUILD_ROOT)/$(PROJECTNAME).xcframework
	rm -rf $(FRAMEWORKS)
	mkdir -p $(FRAMEWORKS)
	mv $(BUILD_ROOT)/$(PROJECTNAME).xcframework $(FRAMEWORKS)/$(PROJECTNAME).xcframework

sharpie:
	sharpie bind --sdk=$(IOS_SDK) --output="$(BINDING_OUTPUT)" --namespace="Drastic.$(PROJECTNAME)" --scope="$(FRAMEWORKS)/$(PROJECTNAME).xcframework/ios-arm64/$(PROJECTNAME).framework/Headers" $(FRAMEWORKS)/$(PROJECTNAME).xcframework/ios-arm64/$(PROJECTNAME).framework/Headers/*.h

nuget:
	dotnet pack --configuration Release