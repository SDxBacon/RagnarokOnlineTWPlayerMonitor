import { config } from "../../wailsjs/go/models";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";

interface ServerSelectProps {
  value: config.LoginServer | null;
  options: config.LoginServer[];
}

const ServerSelect = (props: ServerSelectProps) => {
  const { value, options } = props;
  return (
    <div className="flex flex-col gap-2">
      <p className="text-left text-lg font-bold">Select Server</p>

      <Select
        value={value?.Name}
        // TODO: remove disabled in the future
        disabled
      >
        <SelectTrigger className="w-[180px] rounded-[8px]">
          <SelectValue placeholder="Please select a server" />
        </SelectTrigger>
        <SelectContent>
          {options.map((option) => (
            <SelectItem key={option.Name} value={option.Name}>
              {option.Name}
            </SelectItem>
          ))}
        </SelectContent>
      </Select>
    </div>
  );
};

export default ServerSelect;
