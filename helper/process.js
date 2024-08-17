const { spawn,exec } = require('child_process');
const {logger} = require('../helper/logger');
function KillTask(processName) {
  // const processName = 'notepad.exe';

  // 使用 taskkill 命令终止进程
  exec(`chcp 437&&taskkill /f /im ${processName}`, (error, stdout, stderr) => {
    if (error) {
      // logger.info(`[KillTask] Error executing taskkill: ${error.message}`);
      return;
    }
    if (stderr) {
      logger.info(`[KillTask] taskkill stderr: ${stderr}`);
      return;
    }
    logger.info(`[KillTask] Successfully terminated ${processName}`);
  });
}

function KillAllProcess() {
  KillTask("SpeedNet.exe");
  KillTask("SpeedNet_V2.exe");
  KillTask("SpeedProxy.exe");
  KillTask("SpeedMains.exe");
  KillTask("SpeedFox.tun2socks.exe");
  KillTask("sniproxy.exe");
  KillTask("SpeedNet_brook.exe");
}

// TODO: should callback when failed
function OpenExternalProgram(program) {
  let command;

  switch (os.platform()) {
    case 'darwin': // macOS
      command = `open -a "${program}"`;
      break;
    case 'win32': // Windows
      command = `start "" "${program}"`;
      break;
    case 'linux': // Linux
      command = `xdg-open "${program}"`;
      break;
    default: 
      logger.error('[OpenExternalProgram] Unsupported platform:' + os.platform());
      return;
  }

  exec(command, (error, stdout, stderr) => {
    if (error || stderr) {
      logger.error(`[OpenExternalProgram.exec]: ${error}`);
      return;
    }
    logger.debug(`[OpenExternalProgram.exec]: ${stdout}`);
  });
}

module.exports = {KillAllProcess, OpenExternalProgram};
