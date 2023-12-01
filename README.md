# Slate

편집점 표시용 유틸입니다. 단축키(F12)를 누르면 소리가 납니다.

# 빌드

[.NET SDK](https://dotnet.microsoft.com/en-us/download)가 필요합니다.

```ps
dotnet build -c Release
```

빌드한 폴더에 `assets/pop.wav`를 두세요.

# OBS 설정법

참고: 데스크탑 오디오와 같이 사용할 수 없습니다.

## 오디오 트랙 나누기

설정 > 출력 > 출력 방식: 고급 > 녹화 > 오디오 트랙

1, 2를 제외한 트랙 중 사용할 트랙을 켜주세요.

## Slate 등록하기

소스 목록 > 소스 추가 > [응용 프로그램 오디오 캡쳐](https://obsproject.com/kb/application-audio-capture-guide)

새로 만들기 > Slate로 이름 변경

Slate 두 번 클릭(속성)

1. 윈도우: `[slate.exe]: slate` 
2. 창 탐색 우선 순위: 제목이 일치하거나, 없으면 실행 파일이 같은 창 찾기 > 확인

편집 > 오디오 고급 설정

- Slate 트랙 설정