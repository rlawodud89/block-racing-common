# 🔗 Block Racing Common

> Client와 Server가 공유하는 Network Packet 및 Game Data 모듈

블록 레이싱의 **Unity Client와 C# Dedicated Server가 공통으로 사용하는 데이터 및 네트워크 모듈**입니다.

Client와 Server에서 동일한 Packet, Enum, Snapshot 구조를 사용하도록 분리하여 **통신 데이터의 일관성을 유지하고 Client / Server 간 의존성을 줄이는 것**을 목적으로 구성했습니다.

---

## 📌 Overview

Common은 Client와 Server 사이의 **공통 Contract** 역할을 합니다.

* Network Packet 정의
* Packet Header 및 ID 관리
* Packet Serialization / Deserialization
* Game State Snapshot 정의
* Game 관련 Enum 공유
* Block / Piece 공통 데이터 정의
* Client / Server 데이터 구조 통일
* Git Submodule을 통한 공유

```text
              Block Racing Common
                       │
        ┌──────────────┴──────────────┐
        ▼                             ▼
      Client                        Server
        │                             │
        └────── 동일한 Contract ──────┘
```

---

## 🏗️ Architecture

```text
Common
│
├── Network
│   ├── PacketHeader
│   ├── PacketId
│   ├── IPacket
│   ├── PacketReader
│   ├── PacketWriter
│   ├── ReceiveBuffer
│   └── Packets
│
└── Game
    ├── Enums
    ├── Pieces
    └── Snapshots
```

| 영역         | 역할                        | 구현                            |
| ---------- | ------------------------- | ----------------------------- |
| Network    | Packet 통신 규격              | [`Network`](Network)          |
| Packets    | Client / Server Packet 정의 | [`Packets`](Network/Packets)  |
| Game Enums | 공통 게임 상태 및 타입             | [`Enums`](Game/Enums)         |
| Pieces     | Block Piece 관련 데이터        | [`Pieces`](Game/Pieces)       |
| Snapshots  | Server Game State 전달 구조   | [`Snapshots`](Game/Snapshots) |

---

## 🌐 Network Contract

Client와 Server는 TCP를 통해 Packet을 주고받습니다.

Common에서는 실제 네트워크 연결을 담당하지 않고, **Packet의 구조와 데이터를 정의**합니다.

```text
Client
  │
  │ Packet
  ▼
Serialization
  │
  │ TCP
  ▼
Deserialization
  │
  ▼
Server
```

주요 구성:

* [`IPacket.cs`](Network/IPacket.cs)
* [`PacketHeader.cs`](Network/PacketHeader.cs)
* [`PacketId.cs`](Network/PacketId.cs)
* [`PacketReader.cs`](Network/PacketReader.cs)
* [`PacketWriter.cs`](Network/PacketWriter.cs)
* [`ReceiveBuffer.cs`](Network/ReceiveBuffer.cs)

### Packet 구조

```text
┌─────────────────────────────┐
│ Packet Header               │
│                             │
│ Length                      │
│ Packet ID                   │
├─────────────────────────────┤
│ Payload                     │
└─────────────────────────────┘
```

Client와 Server가 동일한 Packet 정의를 사용하기 때문에 별도의 변환 계층 없이 동일한 데이터 규격으로 통신할 수 있습니다.

---

## 📦 Packet

Packet은 방향에 따라 Client → Server와 Server → Client로 구분합니다.

```text
Client → Server
├── Login
├── Match Request
├── Input
├── Room
├── Ready
├── Rematch
└── Heartbeat

Server → Client
├── Login Result
├── Room Result
├── Room Ready
├── Start Game
├── Game State
├── Game End
├── Game Canceled
├── Opponent Exit
└── Heartbeat
```

현재 Packet 정의는 [`Network/Packets`](Network/Packets)에서 관리합니다.

주요 Packet:

* [`C_LoginPacket`](Network/Packets/C_LoginPacket.cs)
* [`C_MatchRequestPacket`](Network/Packets/C_MatchRequestPacket.cs)
* [`C_InputPacket`](Network/Packets/C_InputPacket.cs)
* [`C_ReadyPacket`](Network/Packets/C_ReadyPacket.cs)
* [`C_RematchRequestPacket`](Network/Packets/C_RematchRequestPacket.cs)
* [`S_GameStatePacket`](Network/Packets/S_GameStatePacket.cs)
* [`S_StartGamePacket`](Network/Packets/S_StartGamePacket.cs)
* [`S_GameEndPacket`](Network/Packets/S_GameEndPacket.cs)

---

## 🔄 Snapshot

Server Authoritative 구조에서 Server의 게임 상태를 Client에 전달하기 위한 **Snapshot 데이터 구조**를 제공합니다.

```text
Server Game State
       │
       ▼
GameStateSnapshot
       │
       ├── Tick
       │
       └── Players
              │
              ├── PlayerSnapshot
              │
              └── LaneSnapshot
                     │
                     ├── Blocks
                     └── FlyingBlocks
```

주요 Snapshot:

* [`GameStateSnapshot.cs`](Game/Snapshots/GameStateSnapshot.cs)
* [`PlayerSnapshot.cs`](Game/Snapshots/PlayerSnapshot.cs)
* [`LaneSnapshot.cs`](Game/Snapshots/LaneSnapshot.cs)
* [`BlockSnapshot.cs`](Game/Snapshots/BlockSnapshot.cs)
* [`FlyingBlockSnapshot.cs`](Game/Snapshots/FlyingBlockSnapshot.cs)

Snapshot을 Common에서 관리함으로써 **Server가 생성한 게임 상태와 Client가 해석하는 게임 상태의 구조를 동일하게 유지**합니다.

---

## 🎮 Game Data

게임 로직에서 공통으로 사용하는 데이터와 Enum을 관리합니다.

### Enums

[`Game/Enums`](Game/Enums)

* `BlockType`
* `GameEndReason`
* `GameEndType`
* `InputType`
* `PieceType`
* `PlayMode`
* `RoomCreateResult`
* `RoomJoinResult`
* `Rotation`

Client와 Server에서 동일한 Enum을 사용하여 **상태 및 Packet 데이터의 의미를 일관되게 유지**합니다.

### Pieces

[`Game/Pieces`](Game/Pieces)

* [`CellPosition.cs`](Game/Pieces/CellPosition.cs)
* [`PieceShapeTable.cs`](Game/Pieces/PieceShapeTable.cs)

Block Piece의 공통적인 위치 및 Shape 데이터를 관리합니다.

---

## 🔗 Client / Server Integration

Common은 Git Submodule로 Client와 Server에 연결하여 사용합니다.

```text
                   Common
                  /      \
                 /        \
                ▼          ▼
             Client      Server
                │          │
                └────┬─────┘
                     │
              Shared Contract
```

이를 통해 다음과 같은 문제를 줄일 수 있습니다.

* Client / Server Packet 구조 불일치
* Enum 값 불일치
* Snapshot 데이터 구조 불일치
* 동일 데이터 구조의 중복 구현
* Protocol 변경 시 양쪽 코드의 수동 수정 누락

공통 데이터 변경이 필요한 경우 Common을 수정하고 Client와 Server에서 해당 Submodule 버전을 업데이트합니다.

---

## 📁 Project Structure

```text
block-racing-common/
│
├── Game/
│   ├── Enums/
│   │   ├── BlockType.cs
│   │   ├── InputType.cs
│   │   ├── PieceType.cs
│   │   ├── PlayMode.cs
│   │   └── ...
│   │
│   ├── Pieces/
│   │   ├── CellPosition.cs
│   │   └── PieceShapeTable.cs
│   │
│   └── Snapshots/
│       ├── BlockSnapshot.cs
│       ├── FlyingBlockSnapshot.cs
│       ├── GameStateSnapshot.cs
│       ├── LaneSnapshot.cs
│       └── PlayerSnapshot.cs
│
├── Network/
│   ├── Packets/
│   │   ├── C_*.cs
│   │   └── S_*.cs
│   │
│   ├── IPacket.cs
│   ├── PacketHeader.cs
│   ├── PacketId.cs
│   ├── PacketReader.cs
│   ├── PacketWriter.cs
│   └── ReceiveBuffer.cs
│
├── BlockRacing.Common.asmdef
├── block-racing-common.csproj
├── block-racing-common.sln
└── README.md
```

---

## 🛠️ Tech Stack

| Category      | Technology                    |
| ------------- | ----------------------------- |
| Language      | C#                            |
| Network Data  | TCP Packet Contract           |
| Client        | Unity                         |
| Server        | .NET 9                        |
| Shared Module | Git Submodule                 |
| Serialization | Custom Packet Reader / Writer |

---

## 🔗 Related Repositories

* [Block Racing](https://github.com/rlawodud89/block-racing)
* [Block Racing Client](https://github.com/rlawodud89/block-racing-client)
* [Block Racing Server](https://github.com/rlawodud89/block-racing-server)

---

## 🎯 Development Focus

Common의 핵심 목표는 **Client와 Server 사이의 데이터 계약을 하나의 모듈로 관리하는 것**입니다.

주요 구현 내용:

* Client / Server 공통 Packet 정의
* Packet Header 및 ID 관리
* Custom Serialization / Deserialization
* Server State Snapshot 공유
* Game Enum 및 데이터 공유
* Git Submodule 기반 공통 코드 관리

이를 통해 Network Protocol과 Game State의 **단일 데이터 규격을 유지**하고, Client와 Server가 서로 다른 데이터 구조를 구현하면서 발생할 수 있는 통신 오류를 줄였습니다.
