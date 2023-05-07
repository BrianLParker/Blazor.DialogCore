// ------------------------------------------------------------
// Copyright (c) 2022, Brian Parker All rights reserved.
// Licensed under the MIT License.
// ------------------------------------------------------------

export function addCloseEventListener(dialog, dotNetHelper) {
    dialog.addEventListener('close', () => {
        dotNetHelper.invokeMethodAsync('OnDialogClosed');
    });
}

export function showDialog(dialog) {
    return dialog.showModal();
}

export function closeDialog(dialog) {
    return dialog.close();
}

export function requestFullscreen(element) {
    if (element.requestFullscreen) {
        element.requestFullscreen();
    }
}

export function exitFullscreen() {
    if (document.exitFullscreen) {
        document.exitFullscreen();
    }
}

export function isElementInFullscreen(element) {
    if (document.fullscreenElement === element) {
        return true;
    }
    return false;
}